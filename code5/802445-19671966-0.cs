    private StreamWriter sw;
    public void CreateLogFile()
    {
         // ...
         sw = File.AppendText(filename);
    }
 
    public void Log(string text)
    {
       lock (sw)
       {
          sw.writeLine(text);
       }
    }
