        Private Shared Function IsWebApiRequest() As Boolean
            Return HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.StartsWith("~/api")
        End Function
    
     Protected Sub Application_PostAuthorizeRequest()
            If IsWebApiRequest() Then
                HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required)
            End If
        End Sub
