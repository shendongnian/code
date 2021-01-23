    int input = 0;
            double num1 = 0;
            double num2 = 0;
            string inputN1 = "";
            string inputN2 = "";
            bool validnum1 = true;
            bool validnum2 = true;
            do{
                Console.WriteLine("Simple Calculator\n\t 1) Add\n\t 2) Subtract\n\t 3) Multiply\n\t 4) Divide\n\t 5) Quit\n\t ", input);
                Console.Write("Enter your Selection: ");
                input = Convert.ToInt32(Console.ReadLine());
                if (input ==5)
                {
                    Console.WriteLine();
                }
                else if (input >5)
                {
                    Console.WriteLine("Invalid Selection.\t Please Try Again");
                }
                else
                {
                    Console.Write("Enter Number 1: ");
                    inputN1 = Console.ReadLine();
                    validnum1 = double.TryParse(inputN1,out num1);
                    Console.Write("Enter Number 2: ");
                    inputN2 = Console.ReadLine();
                    validnum2 = double.TryParse(inputN2,out num2);
                    if (validnum1 != true && validnum2 != true)
                    {
                        Console.WriteLine("Invalid Number Entered");
                        Console.ReadKey();
                        break;
                       // num1 = Convert.ToDouble(inputN1);
                       // num2 = Convert.ToDouble(inputN2);
                    }
                    //else  else will not be required as double.tryparse is succeeded then value will automatically assigned to respective numbers.
                    //{
                        
                    //}
                    switch (input)
                    {
                        case 1:
                            Console.WriteLine("\tResults: {0}", num1+num2);
                            break;
                        case 2:
                            Console.WriteLine("\tResults: {0}", num1-num2);
                            break;
                        case 3:
                            Console.WriteLine("\tResults: {0}", num1*num2);
                            break;
                        case 4:
                            if (num2 == 0)
                            {
                                Console.WriteLine("Cant Divide by Zero/\t Please try Again");
                            }
                            else
                            {
                                Console.WriteLine("\tResults: {0}", num1/num2);
                            }
                            break;
                    }
                    Console.WriteLine("Press any key...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }while (input != 5 && input <5);
            Console.WriteLine("Press any key....");
            Console.ReadKey();
        }
        }
    }
