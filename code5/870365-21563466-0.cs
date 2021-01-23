    var c = new StringBuilder();
    using (var tw = new TextWriter(c))
    {
        using (var writer = new HtmlTextWriter(tw))
        {
            control.RenderControl(writer);
        }
    }
    return c.ToString();
