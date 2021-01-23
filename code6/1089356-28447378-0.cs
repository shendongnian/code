    int webSiteNbr;
    bool result = int.TryParse(WebConfigurationManager.AppSettings["WebSite"], out webSiteNbr);
    PageTab pageTab = PageTab.Home;
    int pageTabVal = (int)pageTab;
    var pagContentList2 = from p in db.PageContents
                          from w in db.WebSites
                          where w.WebSiteID == webSiteNbr && p.PageTab == pageTabVal && p.PageContentSeqNbr == id
                          //select p;
                          select new PageContentVM
                          {
                              PageContentID = p.PageContentID,
                              PageContentLongDesc = p.PageContentLongDesc
                          };
    return PartialView("_PageContentDisplay", pagContentList2.Single());
}
