    Public Class DeviceWatcher_Test
    
        Private WithEvents dw As DeviceWatcher = DeviceInformation.CreateWatcher()
    
        Private Sub Test() Handles MyBase.Load
    
            dw.Start()
    
        End Sub
    
        Private Sub dw_Added(ByVal sender As DeviceWatcher, ByVal e As DeviceInformation) _
        Handles dw.Added
    
            Debug.WriteLine("dw_added: " & e.Id & " | " & e.Name)
    
        End Sub
    
        Private Sub dw_Removed(ByVal sender As DeviceWatcher, ByVal e As DeviceInformationUpdate) _
        Handles dw.Removed
    
            Debug.WriteLine("dw_Removed: " & e.Id)
    
        End Sub
    
        Private Sub dw_Updated(ByVal sender As DeviceWatcher, ByVal e As DeviceInformationUpdate) _
        Handles dw.Updated
    
            Debug.WriteLine("dw_Updated: " & e.Id)
    
        End Sub
    
        Private Sub dw_Stopped(ByVal sender As DeviceWatcher, ByVal e As Object) _
        Handles dw.Stopped
    
            Debug.WriteLine("dw_Stopped: " & e.ToString)
    
        End Sub
    
        Private Sub dw_EnumerationCompleted(ByVal sender As DeviceWatcher, ByVal e As Object) _
        Handles dw.EnumerationCompleted
    
            Debug.WriteLine("dw_EnumerationCompleted: " & e.ToString)
    
        End Sub
    
    End Class
