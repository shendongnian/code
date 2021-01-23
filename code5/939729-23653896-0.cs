    var sb = new StringBuilder();
        sb.Append("<script>");
        sb.Append(string.Format("var jsonObj ={0}", json));
        sb.Append("</script>");
        ClientScript.RegisterStartupScript(this.GetType(), "jsonObjVar", sb.ToString());
