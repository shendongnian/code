    Type type = this.GetType();
    string scriptName = "assign aaa";
    ClientScriptManager clientScript = Page.ClientScript;
    if (!clientScript.IsClientScriptBlockRegistered(type, scripName))
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type=\"text/javascript\">")
          .AppendFormat("var aaa = {0};", JsonConvert.Serialize(aaa))
          .Append("</" + "script>");
        clientScript.RegisterClientScriptBlock(type, scripName, sb.ToString());
    }
    
