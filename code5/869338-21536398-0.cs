    private static readonly log4net.Core.Level _customLevel=new
    log4net.Core.Level(50000,"Custom");
    public void Init()
    {
        log4net.Util.LogLog.InternalDebugging=true;
        log4net.LogManager.GetRepository().LevelMap.Add(_customLevel);
    }
        
    public void WriteToLog(string message)
    {
        log.Logger.log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,_customLevel,message,null);
    }
