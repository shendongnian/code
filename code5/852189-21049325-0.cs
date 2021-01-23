    string command = null;
    while(command != "exit")
    {
       Console.Write(">$");
       ProcessCommand(command=Console.ReadLine());
    }
    
    public static void  ProcessCommand(string Command)
    {
       if(Command == "exit") return;
    }
