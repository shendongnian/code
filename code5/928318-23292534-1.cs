        switch ((FTPCommands)id)
        {
            case FTPCommands.ID:
                RichTxtMessage(arguments,true);
                break;
            case FTPCommands.Error:   
                RichTxtMessage(arguments, true);
                break;
        }
    }
