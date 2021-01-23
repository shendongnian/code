    StringBuilder sb = new StringBuilder();
    sb.Append(File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplate/template.htm")));
    
     //Replace literals
     sb.Replace("<%Name%>", "FirstName");
     sb.Replace("<%EmailAddress%>", "Email");
     sb.Replace("<%Password%>", "password");
