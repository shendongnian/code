     Public Class ChatHub : Inherits Hub
        Public Sub MyTest(ByVal message As String)
            Clients.All.clientFuncTest("Hello from here, your message is: " + message)
        End Sub
     End Class
