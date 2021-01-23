    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Use: app.exe -c config.xml");
            return;
        }
            
        if (args[0] != "-c")
        {
           Console.WriteLine("wrong, please input key '-c' for xml file.");
           return; 
        }
    }
