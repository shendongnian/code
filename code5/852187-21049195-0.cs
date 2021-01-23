    do
    {
      Console.Write(">$");
      continueLoop = ProcessCommand(Console.ReadLine());
    } while (!continueLoop);
    
    public static bool ProcessCommand(string Command)
    {
        return command != "exit";
    }
