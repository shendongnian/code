    public static void CreateWikiPage(ClientContext ctx, string pageName, string pageContent)
    {
            const string templateRedirectionPageMarkup = "<%@ Page Inherits=\"Microsoft.SharePoint.Publishing.TemplateRedirectionPage,Microsoft.SharePoint.Publishing,Version=14.0.0.0,Culture=neutral,PublicKeyToken=71e9bce111e9429c\" %> <%@ Reference VirtualPath=\"~TemplatePageUrl\" %> <%@ Reference VirtualPath=\"~masterurl/custom.master\" %>";
            var wikiPages = ctx.Web.Lists.GetByTitle("Pages");
            var fileInfo = new FileCreationInformation
                {
                    Url = pageName,
                    Content = Encoding.UTF8.GetBytes(templateRedirectionPageMarkup),
                    Overwrite = true
                };
            var wikiFile = wikiPages.RootFolder.Files.Add(fileInfo);
            var wikiPage = wikiFile.ListItemAllFields;
            wikiPage["PublishingPageContent"] = pageContent;
            wikiPage["PublishingPageLayout"] = "/_catalogs/masterpage/EnterpriseWiki.aspx, Basic Page";
            wikiPage.Update();
            ctx.ExecuteQuery();
    }
