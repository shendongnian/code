    private bool IsPPTPresentationRunning()
    {
        Process[] prozesse = Process.GetProcesses();
        foreach (Process p in prozesse)
        {//searches for a running PowerPoint process
            if (p.ProcessName == "POWERPNT")
            {
                try
                {
                    Microsoft.Office.Interop.PowerPoint.Application PPT = new Microsoft.Office.Interop.PowerPoint.Application();
                    if (PPT.SlideShowWindows.Count > 0)
                     return true; 
                    else
                     return false; 
                }//Catches any other exception that seems to get thrown only when powerpoint is not in Presentation mode
                catch (Exception) 
                {
                    return false;
                }
            }
        }
        return false;
    }
