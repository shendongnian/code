    Imports Microsoft.AspNet.Identity
    Imports Microsoft.Owin
    Imports Microsoft.Owin.Security.Cookies
    Imports Owin
    Partial Public Class Startup
   
        Public Sub ConfigureAuth(app As IAppBuilder)
            app.UseCookieAuthentication(New CookieAuthenticationOptions() With {
            .AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            .LoginPath = New PathString("/Account/Login")})
        End Sub
    End Class
