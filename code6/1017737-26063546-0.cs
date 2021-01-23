    Public Class NewMessageEventArgs
        Inherits EventArgs
        Public Property MessageCode As String
        Public Property AppName As String
    End Class
    Public Delegate Sub NewMessageEventHandler(sender As Object, e As NewMessageEventArgs)
    Public Class EventRaiser
        Public Event NewMessage As NewMessageEventHandler
        Public Sub MessageEvent(ByVal typeEvent As String, ByVal messageCode As String, appName As String)
            If (typeEvent = "newMessage") Then
                RaiseEvent NewMessage(Me, New NewMessageEventArgs() With {.AppName = appName, .MessageCode = messageCode})
            End If
        End Sub
    End Class
