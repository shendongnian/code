    Imports Windows.Devices.Enumeration
    
    Public Class Form1
    
        Public WithEvents dw As DeviceWatcher = DeviceInformation.CreateWatcher()
    
        Private Sub dw_Added(ByVal sender As DeviceWatcher, ByVal e As DeviceInformation) _
        Handles dw.Added
    
        End Sub
    
        Private Sub dw_Removed(ByVal sender As DeviceWatcher, ByVal e As DeviceInformationUpdate) _
        Handles dw.Removed
    
        End Sub
    
        Private Sub dw_Stopped(ByVal sender As DeviceWatcher, ByVal e As Object) _
        Handles dw.Stopped
    
        End Sub
    
        Private Sub dw_Updated(ByVal sender As DeviceWatcher, ByVal e As DeviceInformationUpdate) _
        Handles dw.Updated
    
        End Sub
    
    End Class
