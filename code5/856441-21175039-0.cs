    Public Sub New()
        Application.Lock()
        Application("ServiceStarted") = Now()
        Application.UnLock()
    End Sub
