    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadRSS();
        }
    }
    protected void rptRSS_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HyperLink lnkArticle = (HyperLink)e.Item.FindControl("lnkArticle");
            Label lblDescription = (Label)e.Item.FindControl("lblDescription");
            Label lblRSSTitle = (Label)e.Item.FindControl("lblRSSTitle");
            SyndicationItem item = (SyndicationItem)e.Item.DataItem;
                    
            lnkArticle.Text = item.Title.Text;
            lnkArticle.NavigateUrl = item.Links[0].Uri.ToString(); ;
            lblRSSTitle.Text = item.Title.Text;
            lblDescription.Text = item.Summary.Text;
        }
    }
     
    private void LoadRSS()
    {                
        List<SyndicationItem> lstSynItem = new List<SyndicationItem>();
        string uri = "http://www.weather.com/rss/national/rss_nwf_rss.xml?cm_ven=NWF&cm_cat=rss&par=NWF_rss";
        SyndicationFeed myRss = SyndicationFeed.Load(XmlReader.Create(uri));
    
        foreach (SyndicationItem item in myRss.Items)
        {
            lstSynItem.Add(item);
        }
        rptRSS.DataSource = lstSynItem;
        rptRSS.DataBind();
    }
