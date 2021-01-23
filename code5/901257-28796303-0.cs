    var homePage = CurrentPage.AncestorsOrSelf().Where("DocumentTypeAlias == @0", "yourPageAlias").FirstOrDefault();
    
    var umbracoFolder = homePage.yourUmbracoFolderName;
    var umbracoFolderItems = Umbraco.Content(umbracoFolder.ToString());
    
    Umbraco.Web.Models.DynamicPublishedContentList yourList = umbracoFolderItems.yourItems as Umbraco.Web.Models.DynamicPublishedContentList;
