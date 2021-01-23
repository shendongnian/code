    public void WriteLine(string line)
    {
       //add an enter to the end
       line += Environment.NewLine;
       File.AppendAllText(logfile, line);
    }
