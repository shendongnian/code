    static void Main(string[] args)
    {
        while (getKod() != 1946)
        {
            
            System.Threading.Thread.Sleep(3000);
        }
        Console.WriteLine("Unlocked");
    }
    
    
    private int getKod()
    {
        Console.WriteLine("Kod:");
        int kod;
        Int32.TryParse(Console.ReadLine(), out kod);
        return kod;
    }
