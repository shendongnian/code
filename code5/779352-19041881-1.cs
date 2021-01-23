    var processes = Process.GetProcesses().ToList();
    
    foreach (var p in processes)
    {
        try
        {
            var description = FileVersionInfo.GetVersionInfo(p.MainModule.FileName).FileDescription;
            if (description == "Google Chrome")
            {
                Console.WriteLine(p.ProcessName);
                break;
            }
                        
        }
        catch (Exception ex)
        {
            // You will get Access is denied exception for some processes when accesses `MainModule`
        }
    }
