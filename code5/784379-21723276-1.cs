    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
       e.Cancel = true;
       int index = e.NewPageIndex;
       string urlPath =  HttpContext.Current.Request.Url.AbsoluteUri;
       Uri uri = new Uri(urlPath);
       string url = uri.GetLeftPart(UriPartial.Path);
       Response.Redirect(string.Format("{0}?page={1}", url, index));
    }
