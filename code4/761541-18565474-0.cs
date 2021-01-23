    protected void pagesRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        HyperLink lnk = (HyperLink)e.Item.FindControl("hyperlink");
        string[] URL = Request.Url.Segments;
        string currentUrl = URL[URL.Length - 1];
        if (lnk != null)
        {
            string lnkUrl=lnk.NavigateUrl;
            if (lnkUrl == currentUrl)
            {
                lnk.BackColor = Color.Orange;
                lnk.Style.Add("border", "1px solid #000000");
                lnk.Style.Add("background-color", "orange");
                lnk.Style.Add("text-decoration", "none");
            }
        }
    }
