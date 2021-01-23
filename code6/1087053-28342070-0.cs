    StreamWriter str = new StreamWriter("D:\\loop.txt", true);
    str.WriteLine("**** List of Application *********");
    
    Process[] processlist = Process.GetProcesses();
    
    foreach (Process process in processlist)
    {
       if (!String.IsNullOrEmpty(process.MainWindowTitle))
       {
           str.WriteLine("Process: {0} ID :{1} Window Title :{2}", process.ProcessName, process.Id, process.MainWindowTitle);
       }
    }
    
    str.Close(); // You need to close the stream
