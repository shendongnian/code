        StringBuilder sb = new StringBuilder();
        sb.Append("<script>");            
        sb.Append("alert('aa')");
        sb.Append("</script>");
        HtmlGenericControl span = new HtmlGenericControl("span");
        span.InnerHtml = sb.ToString();
        this.form1.Controls.Add(span);
