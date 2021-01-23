    Imports Microsoft.AspNet.FriendlyUrls
    Imports Microsoft.AspNet.FriendlyUrls.Resolvers
    
    Public Module RouteConfig
        Sub RegisterRoutes(ByVal routes As RouteCollection)
            routes.EnableFriendlyUrls(New FriendlyUrlSettings() With {.AutoRedirectMode = RedirectMode.Permanent}, New IFriendlyUrlResolver() {New CustomFriendlyUrlResolver()})
        End Sub
    End Module
    
    Public Class CustomFriendlyUrlResolver
        Inherits WebFormsFriendlyUrlResolver
    
        Public Overrides Function ConvertToFriendlyUrl(path As String) As String
            If HttpContext.Current.Request.PathInfo <> "" Then Return path Else Return MyBase.ConvertToFriendlyUrl(path)
        End Function
    End Class
