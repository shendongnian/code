    Process[] p = Process.GetProcessesByName("yourprocessname");
    if(p.Length > 0) 
    {
        p[0].WaitForExit();
        Console.WriteLine("Finish");    
    }
    else
    { 
        // Do other things
    }
