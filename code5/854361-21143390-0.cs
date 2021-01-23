        Dim proc As Process = Process.GetCurrentProcess()
        //This gets an array of all processes currently running with the same name
        //  as this application.  
        Dim processes As Process() = Process.GetProcessesByName(proc.ProcessName)
        //If there is only one process with this application's name, then it's
        //  THIS process, so there aren't any others by the same name running
        //  right now.  
        If processes.Length > 1 Then
            For Each p As Process In processes
                If p.Id <> proc.Id Then
                    SendMessage(p.MainWindowHandle, RF_TESTMESSAGE, IntPtr.Zero, IntPtr.Zero)
                End If
            Next
        Else
            //Thus, this gets called because there are not other applications with 
            //the same name.
            MessageBox.Show("No other running applications found.")
        End If
