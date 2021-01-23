    interface IStringProcessor   // a bad name, but all of this is rather abstract
    {
        // Those parameter names are highly suspicious -- is string really the
        // correct type for something called "processDate"?
        void ProcessString(string line, string keyword, 
                           string processDate, string processHour);
    }
