    // The message you want to display.
    string message = "your message";
    // Here you will build a script using the StringBuilder object
    // which will be executed, when the onload event of your page will be triggered.
    StringBuilder sb = new StringBuilder();
    sb.Append("<script type = 'text/javascript'>");
    sb.Append("window.onload=function(){");
    sb.Append("alert('");
    sb.Append(message);
    sb.Append("')};");
    sb.Append("</script>");
    // Here you register your client script 
    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
