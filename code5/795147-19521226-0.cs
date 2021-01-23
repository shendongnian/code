       {
        
                    //Console.WriteLine("Please give a positive number. if you enter a negative number its not going to work");
        
                    int invoer;
                    int max;
                    string repeat;
                    
        
        
                    do
                    {
                        //they have given a negative number and wish to try again
                        Console.WriteLine("Please give a positive number.\nIf you enter a negative number its not going to work");
        
                        invoer = 0;
                        max = 0;
                        repeat = "";
                        
                        for (int i = 1; invoer >= 0; i++)
                        {
        
                            Console.Write(i + "> ");
                            invoer = int.Parse(Console.ReadLine());
        
                            if (max < invoer)
                            {
                                max = invoer;
                            }
                        }
        
        
                        Console.WriteLine("Maximum value is: " + max);
        
        
                        Console.WriteLine("do you want to try again? y/n: ");
                        repeat = Console.ReadLine();
        
                    } while (repeat == "y" || repeat == "Y");
        
                    
                }
