    Public Class Download : Implements IHttpHandler
        Implements SessionState.IRequiresSessionState
        Public Sub ProcessRequest(ByVal context As HttpContext) Implements    IHttpHandler.ProcessRequest
            If User.IsLoggedIn() Then 
                'implement your own user validation here
                Dim path as String = "E:\" & Request.QueryString(path).Replace("/", "\")
                Using fs As IO.FileStream = New IO.FileStream(path, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
                    Dim fileLen As Long = fs.Length()
                    Dim fileData(fileLen) As Byte
                    fs.Read(fileData, 0, Integer.Parse(fileLen.ToString()))
                    context.Response.ContentType("application/pdf") 'set as appropriate based on file extension
                    context.Response.BinaryWrite(fileData)
                End Using
            Else
                context.Response.Write("You don't have access to this resource.")
            End If
        End Sub
        Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
            Get
                    Return False
            End Get
        End Property
    
    End Class
