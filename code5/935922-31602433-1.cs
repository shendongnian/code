    <%@ Application Language="VB" %>
    <%@ Import Namespace="System.Web.Routing" %>
    <%@ Import Namespace="System.Web.Http" %>
    <script RunAt="server">
       
        Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
            ' Code that runs on application startup
            RouteTable.Routes.MapHttpRoute(
                 "defaultApi",
                "api/{controller}/{action}/{id}",
                defaults:=New With {.id =     System.Web.Http.RouteParameter.Optional})
        
        End Sub
    
