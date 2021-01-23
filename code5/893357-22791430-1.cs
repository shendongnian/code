    foreach (Control ctrl in Page.Header.Controls)
    {
        var htmlLink = ctrl as HtmlLink;
        if (htmlLink != null)
        {
            if (htmlLink.ID == "admin_style")
                Page.Header.Controls.Remove(htmlLink);
        }
    }
