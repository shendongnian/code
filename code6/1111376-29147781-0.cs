    public static IEnumerable<WebLocation> GetWebLocations(string rootWebUrl)
    {
       List<WebLocation> results;
       using (var cntxt = new ClientContext(rootWebUrl))
       {
           var web = cntxt.Web;
           cntxt.Load(web, w => w.Webs, w => w.Id, w => w.ServerRelativeUrl, w => w.Lists);
           cntxt.ExecuteQuery();
           results = GetWebLocations(cntxt, web, Guid.Empty);
       }
       return results;
    }
    private static List<WebLocation> GetWebLocations(ClientContext cntxt, Web currentWeb, Guid parentId)
    {
       var results = new List<WebLocation>();
       var currentId = currentWeb.Id;
       var url = currentWeb.ServerRelativeUrl;
       var location = new WebLocation { ParentSiteID = parentId, SiteID = currentId, WebUrl = url, HotLinksItems = new List<HotLinksItem>() };
       foreach (var list in currentWeb.Lists)
       {
           cntxt.Load(list, l => l.BaseTemplate, l => l.RootFolder.ServerRelativeUrl);
           cntxt.ExecuteQuery();
           if (list.BaseTemplate == 10003)
           {
              var itemCollection =
                           list.GetItems(new CamlQuery
                           {
                               ViewXml = "<View Scope='RecursiveAll'><ViewFields><FieldRef Name='Title' Nullable='TRUE' /><FieldRef Name='ID' /><ProjectProperty Name='Title' /><ListProperty Name='Title' /></ViewFields></View>"
                           });
               cntxt.Load(itemCollection);
               cntxt.ExecuteQuery();
               foreach (var item in itemCollection)
               {
                   var hotlink = new HotLinksItem
                   {
                       Title = item["Title"] != null ? item["Title"].ToString() : null,
                       ID = item["ID"] != null ? item["ID"].ToString() : null,
                   };
                   location.HotLinksItems.Add(hotlink);
               }
           }
       }
