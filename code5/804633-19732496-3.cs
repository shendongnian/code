    Sub Application_Error()
        Dim ex As Exception = Server.GetLastError()
        Dim troller As New ErrorController()
        troller.LogError(ex, If(Not IsNothing(Request), Request.UrlReferrer.AbsoluteUri, Nothing))
        Server.ClearError()
    End Sub
