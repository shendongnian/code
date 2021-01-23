    private void Page_Load(object sender, EventArgs e)
    {
        Item[] BlogPosts = HomeItem.Axes.SelectItems(@"child::*[@@templatename='BlogComment']");
        if (BlogPosts.Any())
        {
            rptBlogPosts.DataSource = BlogPosts.OrderBy(x => x[Sitecore.FieldIDs.Created]).Reverse();
            rptBlogPosts.DataBind();
        }
    }
    protected void rptBlogPosts_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var currentItem = e.Item.DataItem as Item;
            var scPostName = e.Item.FindControl("PostName") as FieldRenderer;
            var litPostDate = e.Item.FindControl("PostDate") as Literal;
            var scPostComment = e.Item.FindControl("PostComment") as FieldRenderer;
            scPostName.Item = currentItem;
            litPostDate.Text = currentItem.Statistics.Created.ToString("H:mm:ss MM/dd/yy");
            scPostComment.Item = currentItem;
        }
    }
