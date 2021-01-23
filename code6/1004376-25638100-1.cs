                var siteMapSection = new List<SiteMapSection>();
                DL.SectionArticle sa = new NewsFeed.BusinessTier.DataAccessLayer.SectionArticle();
        
                foreach (BE.Section section in BL.Sections.Find(websiteId, parentSectionId))
                {
                    int sectionId = section.Id;
                    var mySection = new SiteMapSection();
                    mySection.sectionUrl = BL.Sections.VirtualPath(section) + ".aspx";
                    mySection.subSection = new List<SiteMapSubSection>();
                    siteMapSection.Add(mySection);// NOTICE CHANGE HERE
        
                    //Debug.WriteLine(siteMapSection[0].sectionUrl);
        
                    foreach (BE.Section subsection in BL.Sections.Find(websiteId, sectionId))
                    {
                        int subSectionId = subsection.Id;
                        
                        var mySubSection = new SiteMapSubSection();
                        mySubSection.subSectionUrl = BL.Sections.VirtualPath(subsection) + ".aspx";
                        mySubSection.article = new List<SiteMapArticle>();
    enter code here
                        mySection.subSection.Add(mySubSection);// NOTICE CHANGE HERE
        
                        //Debug.WriteLine(smss[0].subSectionUrl);
        
                        var articles = sa.GetArticlesForSection(websiteId, subSectionId, 10);
                        foreach (var article in articles)
                        {
                            mySubSection.article.Add(new SiteMapArticle { url = BL.Sections.VirtualPath(subsection) + "/" + article.Code + "-" + UrlEncoding.ArticleEncode(article.Headline) + ".aspx" });// NOTICE CHANGE HERE
        
                            //Debug.WriteLine(sma[0].url);
                        }
                    }
                }
