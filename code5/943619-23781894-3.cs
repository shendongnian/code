    private readonly List<Level> logLevels = new List<Level>
    {
         Level.Alert,
         Level.All,
         Level.Critical,
         Level.Debug,
         Level.Emergency,
         Level.Error,
         Level.Fatal,
         Level.Fine,
         Level.Finer,
         Level.Finest,
         Level.Info,
         Level.Log4Net_Debug,
         Level.Notice,
         Level.Off,
         Level.Severe,
         Level.Trace,
         Level.Verbose,
         Level.Warn
    };
    public IList<Level> EnabledLogLevels(ILog logger)
    {
        List<Level> levels = new List<Level>();
        foreach (Level level in logLevels)
        {
            if (logger.Logger.IsEnabledFor(level))
            {
                levels.Add(level);
            }
        }
   
        return levels;
    }
