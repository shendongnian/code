    class SomeClass
    {
        IStringAnalyzer stringAnalizer;
        ILogger logger;
    
        public SomeClass(IStringAnalyzer stringAnalyzer, ILogger logger)
        {    
            this.logger = logger;
            this.stringAnalyzer = stringAnalyzer;
        }
    
    
        public void SomeMethod(string someParameter)
        {
            if (stringAnalyzer.IsValid(someParameter))
            {
                //do something with someParameter
            }else
            {
                logger.Log("Invalid string");
            }
        }
    }
