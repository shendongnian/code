    bool isCodeWindow = IsCommandAvailable("Edit.GoTo");
    
    private bool IsCommandAvailable(string commandName)
    {
        EnvDTE80.Commands2 commands = dte.Commands as EnvDTE80.Commands2;
        if (commands == null)
            return false;
    
        EnvDTE.Command command = commands.Item(commandName, 0);
        if (command == null)
            return false;
    
        return command.IsAvailable;
    }
