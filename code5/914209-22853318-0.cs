    using (var log = GetLog()){
        log.WriteLine("["+DateTime.Now + "]: ");
    }
...
    public StreamWriter GetLog(){
        if (!File.Exists(@"" + LogFile))
        {
            return new StreamWriter(@"" + LogFile);
        }
        else {
            return File.AppendText(@"" + LogFile);
        }
    }
