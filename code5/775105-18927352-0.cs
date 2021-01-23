    Private Sub StartProcessAndNormalize(Path As String, ProcessName As String, Optional Args As String = "", Optional PrintLog As Boolean = False)
        If PrintLog = True Then Console.WriteLine("Starting --->" + ProcessName)
        StartCmdProcess(Path, Args, ProcessName)
        ProcessBackToNormal(ProcessName)
    End Sub
    Private Sub ProcessBackToNormal(ProcessName As String)
        Dim proc As Process
        Threading.Thread.Sleep(2000)
        proc = (From p In System.Diagnostics.Process.GetProcessesByName(ProcessName) Order By p.StartTime Descending).FirstOrDefault()
        Try
            proc.PriorityClass = ProcessPriorityClass.Normal
        Catch
            Console.WriteLine("Can't find process " & ProcessName)
        End Try
    End Sub
    Private Sub StartCmdProcess(Path As String, Args As String, Optional ProcessName As String = "")
        Dim proc As Process = New Process
        proc.StartInfo.FileName = "cmd.exe"
        proc.StartInfo.Arguments = "/c   start """ & ProcessName & """ /BelowNormal """ & Path & """ " & Args
        proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
        proc.Start()
        proc.WaitForExit()
    End Sub
