    using (FS = File.Create(dailyLog)) { }
    FS.Close();
    StreamWriter TXT_WRITE = new StreamWriter(dailyLog);
    TXT_WRITE.WriteLine(msg);
    TXT_WRITE.Close();
