    ObservableCollection<String> Logs {get; set;}
    
    private void LoadLogs()
    {
       string[] logs = Directory.GetFiles(logPath + logDate, "*.ininlog");
    
       foreach(string logName in logs)
       {
           string s = logName.Substring(logName.IndexOf(logDate) + logDate.Length + 1);
           int extPos = s.LastIndexOf(".");
           s = s.Substring(0, extPos);
           //MessageBox.Show(s);
           Logs.Add(s); //Add the parsed file name to the list
       }
    }
