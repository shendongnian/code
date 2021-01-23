                for (count = 2; count > -1; count-- )
                {
                    Console.WriteLine("Enter a 4 digit pin number");
                    guess = int.Parse(Console.ReadLine());
    
    
    
                    if(guess != pin)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("You entered an incorrect pin number, you have {0}   attempts remaining", count);
                    }
                    else if (guess == pin)
                   {
                      Console.WriteLine("You have entered the correct pin number");
                    }
    
                }
