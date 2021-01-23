    static void Main(string[] args)
    {
        int TurkeyNumber = 0;
        double TurkeyWeight = 0.00;
        int TurkeyCounter = 0;
        int[] G= new int[6];
    
        Console.Write("How many turkeys are you weighing? ");
        TurkeyNumber = Convert.ToInt32(Console.ReadLine());
    
        while (TurkeyCounter < TurkeyNumber)
        {
            Console.WriteLine("\nEnter the weight of turkey number {0}:",TurkeyCounter+1);
            TurkeyWeight = Convert.ToInt32(Console.ReadLine());
    
            if (TurkeyWeight > 12)
               G[0]++;       
            else if (TurkeyWeight > 10)
               G[1]++;
            else if (TurkeyWeight > 8)
               G[2]++;
            else if (TurkeyWeight > 6)
               G[3]++;
            else if (TurkeyWeight > 4)
               G[4]++;
            else if (TurkeyWeight <= 12) 
               G[5]++;
            
            TurkeyCounter++;             
        }
        Console.ReadKey();
    }
  
