    public WebPage ParseHtml(string html, Uri uri)
    {
        var document = new HtmlDocument();
        document.LoadHtml(html);
    
        // remove scripts
        foreach (var script in document.DocumentNode.Descendants("script").ToArray())
        {
            script.Remove();
        }
    
        // remove styles
        foreach (var style in document.DocumentNode.Descendants("style").ToArray())
        {
            style.Remove();
        }
    
        // remove comments
        foreach (var style in document.DocumentNode.Descendants("#comment").ToArray())
        {
            style.Remove();
        }
    
        // sometimes </form> is not removed so we have to remove it manually
        string innerText = (document.DocumentNode.InnerText ?? "").Trim().Replace("</form>", "");
                
        var sb = new StringBuilder();
        var lines = innerText.Split(new[] { Environment.NewLine, "\n" }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var line in lines)
        {
            string trimmed = StringUtils.DecodeAndRemoveSpaces(line);
            if (!string.IsNullOrWhiteSpace(trimmed))
            {
                sb.AppendLine(trimmed);
            }
        }
    
        var webPage = new WebPage { PageUrl = uri.AbsoluteUri };
    
        var titleNode = document.DocumentNode.Descendants("title").SingleOrDefault();
        if (titleNode != null)
        {
            webPage.Title = StringUtils.DecodeAndRemoveSpaces(titleNode.InnerText ?? "");
        }
    
        webPage.Text = sb.ToString();
    
        return webPage;
    }
