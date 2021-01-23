    <%@ Page language="C#" %>
    <%@ Import Namespace="System.Reflection"  %>
    <%@ Import Namespace="System.Web"  %>
    <%
        var serviceType = "TestService.Service1";
        
        Type type = null;
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
        for (int i = 0; i < assemblies.Length; i++)
        {
            type = assemblies[i].GetType(serviceType, false);
            if (type != null)
            {
                Response.Write("Found it! " + type.ToString());
                break;
            }
        }
        if (type == null)
        {
            Response.Write("Not found");
        }
    %>
