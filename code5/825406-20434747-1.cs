    <Authorize>
    Public Class HomeController
        Inherits System.Web.Mvc.Controller
    
        <HttpGet>
        Function Index() As ActionResult
            Return View()
        End Function
    
    End Class
