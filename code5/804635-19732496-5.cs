    Sub Application_Error()
        Dim ex As Exception = Server.GetLastError()
        Dim page As String = If(Not IsNothing(Request), Request.UrlReferrer.AbsoluteUri, Nothing)
        ErrorController.LogError(ex, page)
        Server.ClearError()
    End Sub
