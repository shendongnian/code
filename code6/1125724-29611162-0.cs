    using System;
    namespace IsItPrime
    {
        class Program
        {
            static void Main(string[] args)
            {
                bool exit = false;
                while (!exit) {
                    Console.WriteLine("Write a natural number:");
                    string answer = Console.ReadLine();
                    if (answer.Equals("x")) { 
                        exit = true;
                    }
                    else 
                    {
                        int number = int.Parse(answer);
                        if (number == 1)
                        {
                            Console.WriteLine("Not prime"); //is 1 prime?
                        }
                        else if (number == 2)
                        {
                            Console.WriteLine("Not Prime");
                        }
                        else if (number % 2 == 0)
                        {
                            Console.WriteLine("Not prime");
                        }
                        else
                        {
                            bool isPrime = false;
                            for (int i = 3; i < number; i += 2)
                            {
                                if (number % i == 0)
                                {
                                    isPrime = true;
                                    break;
                                }
                            }
                            if (isPrime)
                            {
                                Console.WriteLine("Not Prime");
                            }
                            else
                            {
                                Console.WriteLine("Is Prime");
                            }
                        }
	                }
                }
            }
        }
    }
