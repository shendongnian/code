    static void Main(string[] args)
    {
        TimerCallback tmCallback = CheckEffectExpiry; 
        Timer timer =  new Timer(tmCallback,"test",1000,1000);
        Console.WriteLine("Press any key to exit the sample");
        Console.ReadLine(); 
    }
    static  void CheckEffectExpiry(object objectInfo)
    {
        //TODO put your code
    }
