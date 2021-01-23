    if (IsCommandAvailable("TestExplorer.RunAllTests"))
                    _applicationObject.ExecuteCommand("TestExplorer.RunAllTests");
    bool IsCommandAvailable(string command) 
    {
    	Commands2 commands = (Commands2)(_applicationObject.Commands);
	    if (commands == null)
		    return false;
    	Command dte_command = commands.Item(command, 0);
    	if (dte_command == null)
	    	return false;
	    return dte_command.IsAvailable;
    }
