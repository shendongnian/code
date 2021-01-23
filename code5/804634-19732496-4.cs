    Sub Application_Error()
        Dim ex As Exception = Server.GetLastError()
        ErrorController.LogError(ex, If(Not IsNothing(Request), Request.UrlReferrer.AbsoluteUri, Nothing))
        Server.ClearError()
    End Sub
