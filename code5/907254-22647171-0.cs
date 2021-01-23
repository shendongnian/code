    Public Delegate Sub ChangeMessageEvent(ByVal message As String)
    Public Shared Event ChangeMessage As ChangeMessageEvent
    
    Private Sub test()
    	If oStatusManager.ChangeMessageEvent IsNot Nothing Then
    		RaiseEvent oStatusManager.ChangeMessage(message)
    		Application.DoEvents()
    	End If
    End Sub
