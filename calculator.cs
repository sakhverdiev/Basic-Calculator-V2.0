using System;

namespace BasicCalculator
{
    internal class Program
    {
        static public double Add(double a, double b)
        {
            return a + b;
        }

        static public double Subtract(double a, double b)
        {
            return a - b;
        }

        static public double Multiply(double a, double b)
        {
            return a * b;
        }

        static public double Divide(double a, double b)
        {
            return a / b;
        }

        static public void Print(int index, in string[] arr)
        {
            Console.Clear();

            for (int i = 0; i < arr.Length; i++)
            {
                if (i == index)
                {
                    if (arr[i] == "Exit")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine(arr[i]);
            }
        }

        static public void Calculate(string operation, double num1, double num2)
        {
            switch (operation.ToLower())
            {
                case "add":
                    Console.WriteLine($"{num1} + {num2} = {Add(num1, num2)}");
                    break;
                case "subtract":
                    Console.WriteLine($"{num1} - {num2} = {Subtract(num1, num2)}");
                    break;
                case "multiply":
                    Console.WriteLine($"{num1} * {num2} = {Multiply(num1, num2)}");
                    break;
                case "divide":
                    if (num2 != 0)
                    {
                        Console.WriteLine($"{num1} / {num2} = {Divide(num1, num2)}");
                    }
                    else
                    {
                        Console.WriteLine("Division by zero is not allowed");
                    }
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid operation.");
                    break;
            }
            System.Threading.Thread.Sleep(1500);
        }

        static void Main(string[] args)
        {
            string[] arr = { "Add", "Subtract", "Multiply", "Divide", "Exit" };

            int index = 0;
            Print(index, arr);

            while (true)
            {
                Print(index, arr);
                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (index > 0) index--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (index < arr.Length - 1) index++;
                        break;
                    case ConsoleKey.Enter:
                        if (arr[index] == "Exit")
                        {
                            Environment.Exit(0);
                        }

                        Console.Write("\nEnter number 1: ");
                        double num1 = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter number 2: ");
                        double num2 = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine();
                        Calculate(arr[index], num1, num2);
                        index = 0;
                        break;
                }
            }
        }
    }
}