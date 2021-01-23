    bool continueLoop;
    do
    {
      Console.Write(">$");
      continueLoop = ProcessCommand(Console.ReadLine());
    } while (!continueLoop);
    
    public static bool ProcessCommand(string command)
    {
        return command != "exit";
    }
