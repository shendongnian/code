    <AttributeUsage(AttributeTargets.Class Or AttributeTargets.Method, Inherited:=True, AllowMultiple:=True)>
    Class cAuthorizeAttribute
        Inherits AuthorizeAttribute
        Protected Overrides Sub HandleUnauthorizedRequest(filterContext As AuthorizationContext)
            Dim strLanguage As String = filterContext.RouteData.Values("lang")
            If Not strLanguage Is Nothing Then
                filterContext.Result = New RedirectResult(String.Format("~/{0}/Account/Login?returnUrl={1}", strLanguage, HttpUtility.UrlEncode(filterContext.HttpContext.Request.Url.PathAndQuery)))
            Else
                MyBase.HandleUnauthorizedRequest(filterContext)
            End If
        End Sub
    End Class
