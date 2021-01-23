    Public Class MyClassActionFilter
        Inherits ActionFilterAttribute
    	
    	Public Overrides Sub OnActionExecuted(contexto As HttpActionExecutedContext)
    		contexto.Request.Properties.Item("MS_HttpRouteData").Values("controller")
    		contexto.Request.Properties.Item("MS_HttpRouteData").Values("action")
    	End Sub
    	
    	Public Sub New
    	
    	End Sub
    
    End Class
