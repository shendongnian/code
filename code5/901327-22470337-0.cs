    class Program
        {
            static void Main(string[] args)
            {
                int input = 0;
                double num1 = 0;
                double num2 = 0;
                string inputN1 = "";
                string inputN2 = "";
    
                do
                {
                    Console.WriteLine("Simple Calculator\n\t 1) Add\n\t 2) Subtract\n\t 3) Multiply\n\t 4) Divide\n\t 5) Quit\n\t ", input);
                    Console.Write("Enter Selection: ");
                    input = Convert.ToInt32(Console.ReadLine());
    
                    if (input == 5)
                    {
                        Console.WriteLine();
                    }
                    else if (input > 5)
                    {
                        Console.WriteLine("Invalid Menu Selection.\t Try Again");
                    }
    
                    else
                    {
                        Console.Write("Enter Number 1: ");
                        inputN1 = Valid(Console.ReadLine());
                        num1 = Convert.ToDouble(inputN1);
                        Console.Write("Enter Number 2: ", num2);
                        inputN2 = Valid(Console.ReadLine());
                        num2 = Convert.ToDouble(inputN2);
    
    
                        switch (input)
                        {
                            case 1:
                                Console.WriteLine("\tResults: {0}", Add(num1, num2));
                                break;
                            case 2:
                                Console.WriteLine("\tResults: {0}", Subtract(num1, num2));
                                break;
                            case 3:
                                Console.WriteLine("\tResults: {0}", Multiply(num1, num2));
                                break;
                            case 4:
                                if (num2 == 0)
                                {
                                    Console.WriteLine("Can't Divide by Zero.\t Try Again");
    
                                }
                                else
                                {
                                    Console.WriteLine("\tResults: {0}", Divide(num1, num2));
    
                                }
                                break;
                        }
                        Console.WriteLine("Press any key...");
                        Console.ReadKey();
                        Console.Clear();
                    }
    
                }
                while (input != 5 && input < 5);
    
                Console.WriteLine("Press any key...");
                Console.ReadKey();
            } //End of main
            public static string Valid(string validnum)
            {
                string validEntry = "1";
    
                double number = 0;
                bool result = Double.TryParse(validnum, out number);
                if (!result)
                {
                    validEntry = "0";
                }
                else
                {
                    validEntry = number.ToString();
                }
    
                return validEntry;
    
            }
            public static double Add(double num1, double num2)
            {
                return num1 + num2;
            }
            public static double Subtract(double num1, double num2)
            {
                return num1 - num2;
            }
            public static double Multiply(double num1, double num2)
            {
                return num1 * num2;
            }
            public static double Divide(double num1, double num2)
            {
                return num1 / num2;
    
            }
        }
