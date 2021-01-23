    static void Main(string[] args)
                {
                    int retVal=0; 
                    string numberIn;
                    int numberOut;
                    numberIn = Console.ReadLine();
                     
                    while(noNegatives(numberIn,numberOut)=0)
                    {
                         
                    }
                 } 
        
        int noNegatives(String numberIn,int numberOut)
        {
        
        
                    numberIn = Console.ReadLine();
        
                    if (!int.TryParse(numberIn, out numberOut) || numberOut < 0)
                    {
                        Console.WriteLine("Invalid. Enter a number that's 0 or higher.");
                        return 0;
                        
                    }
                    else
                    {
                       return 1;
                    }
        }
