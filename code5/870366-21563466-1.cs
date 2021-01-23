    // create control and make it part of a form and page
    …
    // render just the control
    var c = new StringBuilder();
    using (var sw = new StringWriter(c))
    {
        using (var writer = new HtmlTextWriter(sw))
        {
            control.RenderControl(writer);
        }
    }
    return c.ToString();
