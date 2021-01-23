    public class LogEntry{
        
        public string Date;
        public string Cost;
    
        
        public LogEntry(string date,string cost){
            Date=date;
            Cost=cost;
        }
    
    }
    
    ...
    
    // Grab the lines from the file:
    string[] lines = File.ReadAllLines("log.txt");
    // Create our output set:
    LogEntry[] logEntries=new LogEntry[lines.Length];
    
    // For each line in the file:
    for(int i=0;i<lines.Length;i++){
        // Split the line:
        string[] linePieces=lines[i].Split('|');
        
        // Safety check - make sure this is a line we want:
        if(linePieces.Length!=2){
            // No thanks!
            continue;
        }
        
        // Create the entry:
        logEntries[i]=new LogEntry( linePieces[0] , linePieces[1] );
    }
    // Do something with logEntries.
