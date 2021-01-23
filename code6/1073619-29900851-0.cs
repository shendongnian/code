    private string RenderControl(Control control)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter writer = new HtmlTextWriter(sw);
        if(control.Id=="ProImg"){
          control.Click += new System.EventHandler(this.ProImg_Click);
         }
        control.RenderControl(writer);
        return sb.ToString();
    }
