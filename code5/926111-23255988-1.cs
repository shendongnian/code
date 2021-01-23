     foreach (string logName in logs)
     {
       string s = logName.Substring(logName.IndexOf(ldate) + ldate.Length + 1);
       int extPos = s.LastIndexOf(".");                    // <- finds the extension
       s = s.Substring(0, extPos);                         // <- removes the extension
       s = s.ToUpper();                                    // <- converts to uppercase
       Log newItem = new Log();
       newItem.LogName = s;
       newItem.LogWriteTime = GetFileAccessTime(s)
       logList.Add(s);                                     // <- adds the items it finds
    
     }
     public DateTime GetFileAccessTime(string sFile)
     {
       FileInfo info = new FileInfo(sFile);
    
       return info.LastWriteTime;
     }
