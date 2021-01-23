    public static void Main()
        {
            int input = 1;
            //string enter;
           FizzBuzz fb = new FizzBuzz(); // create a single instance
           fb.BeginTesting(); // start testing
    
            while (input <= 20)
            {
                //Console.WriteLine("Please enter a number: ");
                //enter = Console.ReadLine();
                //input = int.Parse(enter);
                fb.IsFizz(input);
                fb.IsBuzz(input);
                fb.IsFizzBuzz(input);                
                fb.IsPrime(input);
    
                input++;
            }
            fb.TotalFizz();            
            fb.TotalBuzz();            
            fb.TotalFizzBuzz();            
            fb.TotalPrime();
        }
