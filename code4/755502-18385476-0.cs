    using System.Diagnostics;
    
    Process[] procList = Process.GetProcesses();
    
    foreach(Process p in procList ){
        if(p.ProcessName == "<visual studio process name>")
        { /*start the timer*/}
    }
