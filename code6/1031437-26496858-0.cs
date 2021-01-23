    class Log {
    
       .....
       List<string> logData; 
    
       public List<string> LogData { //PROPERTY ACTUALLY BINDED TO LIST VIEW UI
            get {
                return logData;
            }         
       }
        
       public void AddLog(string s) {
             logData.Add(s);
             NotifyPropertyChanged(.. LogData  ..);
       }
   
    }
