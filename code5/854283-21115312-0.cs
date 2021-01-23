    class SomeServerApi
    {
        private Logger _log;
        private LogEventInfo _theevent;
        public SomeServerApi()
        {
            _log = LogManager.GetCurrentClassLogger();
            _theEvent = new LogEventInfo(LogLevel.Debug, "", "Pass my custom value");
        }
        public void SomeMethod()
        {
           //something happens here
            _theEvent.Properties["MyValue"] = "My custom string";
            _log.Log(theEvent);
        }
    }
