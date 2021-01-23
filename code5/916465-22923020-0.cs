    public void RunOnServerOnly(Action execFunc, string errorMessage)
    {
        if (!Game.Instance.SERVER)
        {
            Util.Log(LogManager.LogLevel.Error, errorMessage);
        }
        else
        {
           execFunc();
        }
    }
