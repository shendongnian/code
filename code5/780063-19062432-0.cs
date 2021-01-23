    public class LogLine 
    {
       public string Line { get; set; }
       public LogLine(string line) 
       {
          Line = line;
       }
    }
    // usage
    var ll = new LogLine(l);
