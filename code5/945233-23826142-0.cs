    /// <summary>
    /// Disables the link button.
    /// </summary>
    /// <param name="linkButton">The LinkButton to be disabled.</param>
    public static void DisableLinkButton(LinkButton linkButton)
    {
        linkButton.Attributes.Remove("href");
        linkButton.Attributes.CssStyle[HtmlTextWriterStyle.Color] = "gray";
        linkButton.Attributes.CssStyle[HtmlTextWriterStyle.Cursor] = "default";
        if (linkButton.Enabled != false)
        {
           linkButton.Enabled = false;
        }
    
        if (linkButton.OnClientClick != null)
        {
            linkButton.OnClientClick = null;
        }
    }
