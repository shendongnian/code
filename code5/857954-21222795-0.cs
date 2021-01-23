    <%@ import Newtonsoft.Json.Linq; %>
    <%@ import System; %>
    <%@using Project.Models;%>
    <%@using Project.Controllers;%>
    <%
        WebIntegrationRestService<int,int> service= new WebIntegrationRestService<int,int>();
        service.GetUserByUsername(0,1,User.Identity.Name);
        UserType type = null;
        if (User.Identity.IsAuthenticated)
        {
            UserType type = service.GetUserByUsername(0, 1, User.Identity.Name).First().UserType;
        }
        if (type==UserType.TypeA){%>
        <li><%: Html.ActionLink("Add User ", "Create", "User")%></li>        
        
        <% } %>
