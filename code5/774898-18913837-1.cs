    public override void Render(HtmlTextWriter writer){
        var sb = new StringBuilder();
        using(var sw = new StringWriter(sb)){
            this.RenderControl(sw);
        }
        
        var htmlResult = sb.ToString();
        
        var patchedHtml = DoSomething(htmlResult);
        
        writer.Writer(patchedHtml);
    }
