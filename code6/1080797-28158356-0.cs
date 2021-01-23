    class PagesManager
    {
        public static ListItemCollection LoadPages(ClientContext ctx)
        {
            var pagesList = ctx.Web.Lists.GetByTitle("Pages");
            var pageItems = pagesList.GetItems(CamlQuery.CreateAllItemsQuery());
            ctx.Load(pageItems);
            ctx.ExecuteQuery();
            return pageItems;
        }
        public static void CreatePublishingPage(ClientContext ctx, string pageName,string pageLayoutName)
        {
            var pubWeb = PublishingWeb.GetPublishingWeb(ctx, ctx.Web);
            var pageInfo = new PublishingPageInformation();
            pageInfo.Name = pageName;
            pageInfo.PageLayoutListItem = GetPageLayout(ctx,pageLayoutName);
            var publishingPage = pubWeb.AddPublishingPage(pageInfo);
            ctx.ExecuteQuery();
        }
        public static ListItem GetPageLayout(ClientContext ctx,string name)
        {
            var list = ctx.Site.GetCatalog((int)ListTemplateType.MasterPageCatalog);
            var qry = new CamlQuery();
            qry.ViewXml = string.Format("<View><Query><Where><Eq><FieldRef Name='FileLeafRef' /><Value Type='Text'>{0}</Value></Eq></Where></Query></View>", name);
            var result = list.GetItems(qry);
            ctx.Load(result);
            ctx.ExecuteQuery();
            var item = result.FirstOrDefault();
            return item;
        }
    }
 
