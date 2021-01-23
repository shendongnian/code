    StringBuilder sb = new StringBuilder();
    StringWriter sw = new StringWriter(sb);
    HtmlTextWriter hw = new HtmlTextWriter(sw);
    control.RenderControl(hw);
    Response.Output.Write(sb.ToString());
