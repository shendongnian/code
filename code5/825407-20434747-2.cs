    Imports System.Security.Claims
    Imports System.Threading.Tasks
    Imports Microsoft.AspNet.Identity
    Imports Microsoft.AspNet.Identity.Owin
    Imports Microsoft.Owin.Security
    
    <Authorize>
    Public Class AccountController
        Inherits Controller
    
        Private Function AuthenticationManager() As IAuthenticationManager
            Return HttpContext.GetOwinContext().Authentication
        End Function
    
        <AllowAnonymous>
        Public Function Login(returnUrl As String) As ActionResult
            ViewBag.ReturnUrl = returnUrl
            Return View()
        End Function
    
        <HttpPost>
        <AllowAnonymous>
        <ValidateAntiForgeryToken>
        Public Function Login(model As LoginViewModel, returnUrl As String) As ActionResult
            If ModelState.IsValid Then
    
                If model.UsuarioValido Then 'Local authentication, this must be on Repository class
                    Dim Identidad = New ClaimsIdentity({New Claim(ClaimTypes.Name, model.UserName)},
                                                       DefaultAuthenticationTypes.ApplicationCookie,
                                                       ClaimTypes.Name,
                                                       ClaimTypes.Role)
    
                    Identidad.AddClaim(New Claim(ClaimTypes.Role, "Invitado"))
    
                    AuthenticationManager.SignIn(New AuthenticationProperties() With {.IsPersistent = model.RememberMe}, Identidad)
    
                    Return RedirectToAction("index", "home")
    
                End If
            End If
    
            Return RedirectToAction("login", model)
    
        End Function
    
        <HttpGet>
        Public Function LogOff() As ActionResult
            AuthenticationManager.SignOut()
            Return RedirectToAction("login")
        End Function
    
    End Class
