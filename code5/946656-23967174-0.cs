    protected static string RenderPartialToString(string view, object model)
    {
        string partialViewPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, view.Replace("~/", ""));
        string template = File.ReadAllText(partialViewPath);
        DynamicViewBag viewBag = new DynamicViewBag();
        viewBag.AddValue("UploadFileFromUrl", true);
        string html = Razor.Parse(template, model, viewBag, null);
    
        return html;
    }
