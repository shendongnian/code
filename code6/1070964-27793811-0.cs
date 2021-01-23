    using System;
    
    namespace TestConcept
    {
        class Program
        {
            static void Main(string[] args)
            {
                string countryCodeStr;
                int contryCodeInt;
                string[] arr = new string[6];
                arr[0] = "Us";
                arr[1] = "Canada";
                arr[2] = "Uk";
                arr[3] = "China";
                arr[4] = "India";
                arr[5] = "Korea";
    
                do
                {
                    Console.WriteLine("Choose a Country Code from 0-5 (or -1 to quit):");
                    countryCodeStr = Console.ReadLine();
                    contryCodeInt = Convert.ToInt32(countryCodeStr);
                    switch (contryCodeInt)
                    {
                        case 0:
                            Console.WriteLine("Selected Country :" + arr[0]);
                            break;
                        case 1:
                            Console.WriteLine("Selected Country :" + arr[1]);
                            break;
                        case 2:
                            Console.WriteLine("Selected Country :" + arr[2]);
                            break;
                        case 3:
                            Console.WriteLine("Selected Country :" + arr[3]);
                            break;
    
                        case 4:
                            Console.WriteLine("Selected Country :" + arr[4]);
                            break;
                        case 5:
                            Console.WriteLine("Selected Country :" + arr[5]);
                            break;
    
                        default:
                            Console.WriteLine("Invalid selection. Please select -1 to 5");
                            break;
                    }
                } while (contryCodeInt != -1);
    
                if (contryCodeInt == -1)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
