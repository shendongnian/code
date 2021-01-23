    protected virtual void OnCustomCommand(int command)
    {
        switch(command)
        {
            case 128:
                new VirtualServerInit(EventLogger).Run();
                EventLogger.Write("VirtualServerInit code was executed");            
                // maybe keep state if this only can be run once
                break;
            default:
               EventLogger.Write(String.Format("Unknown control code:{0}", command);            
               break;
        }
    }
