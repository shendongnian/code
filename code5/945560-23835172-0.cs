    static readonly DateTime Epoch = new DateTime(1970, 1, 1);
    
    public static double DateTime2Epoch(DateTime dt, bool convertToUTC = true)
    {
        if (convertToUTC) dt = dt.ToUniversalTime();
        return dt.Subtract(Epoch).TotalSeconds;
    }
    
    [STAThread]
    static void Main(string[] args)
    {
        DateTime dt = new DateTime(2014, 5, 23, 17, 2, 50);
        Console.WriteLine(DateTime2Epoch(dt));  //1400857370    // I'm GMT+2
        Console.WriteLine(DateTime2Epoch(dt, false));  //1400864570
    }
