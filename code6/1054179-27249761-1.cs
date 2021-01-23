    HtmlLink link = new HtmlLink();
    link.Href = "Cases/EditStyles.css";
    link.Attributes.Add("type", "text/css");
    link.Attributes.Add("rel", "stylesheet");
    //check if it exsists on the page header control first
    foreach (Control control in pg.Header.Controls)
    {
        if ((control is HtmlLink) &&
            (control as HtmlLink).Href == href)
        {
            return true;
        }
    }
    pg.Header.Controls.Add(link);
