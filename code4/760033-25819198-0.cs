    class Program
    {
        static  int factorTotal = 1;
        static void Main(string[] args)
        {
                int count = 1;
                while (count <= 10000)
                {
                    bool isPerfect = IsPerfectNumber(count);
                    if (isPerfect && (factorTotal >1))
                    {
                        Console.WriteLine("Is Perfect: {0}", factorTotal);
                        
                    }              
                                    
                    factorTotal = 1;
                    count++;
                }               
                     
           
        } // end main
        static bool IsPerfectNumber(int n)
        {
            int temp;
            int counter = 2;
          
            bool IsPerfect = false;
            while (counter <= (n - 1))
            {
                temp = n % counter;
                if (temp == 0)  // if true than factor found
                {
                    factorTotal = factorTotal + counter;
                }
                counter++;
            }
            if ((factorTotal) == n)
                IsPerfect = true;
            else
                IsPerfect = false;
            return IsPerfect;
        }
    }//end class
