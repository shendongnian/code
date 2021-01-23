    static void Main(string[] args)
    {
        int TurkeyNumber = 0;
        double TurkeyWeight = 0.00;
        int TurkeyCounter = 0;
        int G1 = 0, G2 = 0, G3 = 0, G4 = 0, G5 = 0, G6 = 0; 
    
        Console.Write("How many turkeys are you weighing? ");
        TurkeyNumber = Convert.ToInt32(Console.ReadLine());
    
        while (TurkeyCounter < TurkeyNumber)
        {
            Console.WriteLine("\nEnter the weight of turkey number {0}:",TurkeyCounter+1);
            TurkeyWeight = Convert.ToInt32(Console.ReadLine());
    
            if (TurkeyWeight > 12)
               G1++;       
            else if (TurkeyWeight > 10)
               G2++;
            else if (TurkeyWeight > 8)
               G3++;
            else if (TurkeyWeight > 6)
               G4++;
            else if (TurkeyWeight > 4)
               G5++;
            else if (TurkeyWeight <= 12) 
               G6++;
            
            TurkeyCounter++;             
        }
        Console.ReadKey();
    }
  
