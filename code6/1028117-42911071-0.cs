        static void Main()
        {
            int Totalcoffeecost = 0;
            string Userdecision = string.Empty;
            do
            {
                int userchoice =-1;
                do
            {
                    
            Console.WriteLine("Please enter your coffee size: 1-small, 2-Medum,3-Large");
           userchoice = int.Parse(Console.ReadLine());
                }while(
            
                
                
                
                
         switch (userchoice)
            {
                case 1:
                    Totalcoffeecost += 1;
                    break;
                case 2:
                    Totalcoffeecost += 2;
                    break;
                case 3:
                    Totalcoffeecost += 3;
                    break;
                default:
                    Console.WriteLine("Your choice {0} is invalid", userchoice);
                    break;
            } 
            while(userchoice !=1 && userchoice !=2 && userchoice !=3)
                do
                {
                    Console.WriteLine("Do you want to buy another coffee-Yes or No");
                    string userdecision = "";
                    userdecision = Console.ReadLine().ToUpper();
                    if(userdecision != "Yes" && userdecision !="No")
                    {
                        Console.WriteLine("your choice {0} is invalid. Please try again",userdecision);
                    }
                }while(Userdecision != "Yes" && Userdecision != "No");
                }
            while(Userdecision.ToUpper()!="No");
            Console.WriteLine("Thank you for shopping with us");
            Console.WriteLine("Bill amount={0}",Totalcoffeecost );
        
            
            }
            }
    
            
            
    
            
    
