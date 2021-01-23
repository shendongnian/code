    public SomeClass
    {
        //(snip)
        private void Log(string logMessage, [CallerMemberName]string callerName = null)
        {
            if (logger.IsDebugEnabled)
            {
                string className = typeof(SomeClass).Name;
                logger.DebugFormat("Executing Method = {1};{2}.{0}", logMessage, callerName, className);
            }
        }
    }
