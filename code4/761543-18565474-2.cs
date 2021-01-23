    public class p
    {
        public string Page { get; set; }
        public string Url { get; set; }
        public p(string url, string page)
        {
            Page = page;
            Url = url;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        List<p> arr = new List<p>();
        arr.Add(new p("a.aspx", "a"));
        arr.Add(new p("b.aspx", "b"));
        pagesRepeater.DataSource = arr;
        pagesRepeater.DataBind();
    }
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
