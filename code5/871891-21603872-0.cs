    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to c#");
        string input = Console.ReadLine();
        if(input.ToUpper() == "DOWNLOADPOS")
           DownloadPOS();
    }
