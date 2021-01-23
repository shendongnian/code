     protected void Page_Load(object sender, EventArgs e)
     {
          if(!Page.IsPostBack)
          {
               rptMyButtons.DataSource = //your data from the database
               rptMyButtons.DataBind();
          }
     }
    protected void rptMyButtons_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
             MyButton button = (MyButton)e.Item.DataItem;
             HyperLink hypUrl = (HyperLink)e.Item.FindControl("hypUrl");
             hypUrl.Text = button.Name;
             hypUrl.NavigateUrl = button.Href;
        }
    }
