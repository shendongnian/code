    public class TableVars
    {
        public Dictionary<string,string> loggingTable { get; set; }
        public TableVars()
        {
            loggingTable = new Dictionary<string,string>();
        }
        public void createLogList()
        {
            loggingTable = new Dictionary<string, string>();
        }
    }
    
    foreach( KeyValuePair<string, string> kvp in tablevars.loggingTable)
    {
        //loggingTagle is now a KeyValuePair 
    }
