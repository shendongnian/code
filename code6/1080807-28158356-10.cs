    public static void CreatePublishingPage(ClientContext ctx, string pageName,string pageLayoutName,IDictionary<string,object> properties)
    {
        var pubWeb = PublishingWeb.GetPublishingWeb(ctx, ctx.Web);
        var pageInfo = new PublishingPageInformation();
        pageInfo.Name = pageName;
        pageInfo.PageLayoutListItem = GetPageLayout(ctx,pageLayoutName);
        var publishingPage = pubWeb.AddPublishingPage(pageInfo);
        var pageItem = publishingPage.ListItem;
        foreach (var p in properties)
        {
            pageItem[p.Key] = p.Value; 
        }
        pageItem.Update();
        ctx.ExecuteQuery();
    }
