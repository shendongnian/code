    public static bool  ProcessCommand(string Command)
    {
        if(command == "exit") return false;
    }
    while(command != "exit")
    {
      Console.Write(">$");
      if(!ProcessCommand(Console.ReadLine())) break;
    }
