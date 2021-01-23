                var siteMapSection = new List<SiteMapSection>();
                DL.SectionArticle sa = new NewsFeed.BusinessTier.DataAccessLayer.SectionArticle();
        
                foreach (BE.Section section in BL.Sections.Find(websiteId, parentSectionId))
                {
                    int sectionId = section.Id;
                    siteMapSection.Add(new SiteMapSection { sectionUrl = BL.Sections.VirtualPath(section) + ".aspx" , subSection = new List<SiteMapSubSection>() });// NOTICE CHANGE HERE
        
                    //Debug.WriteLine(siteMapSection[0].sectionUrl);
        
                    foreach (BE.Section subsection in BL.Sections.Find(websiteId, sectionId))
                    {
                        int subSectionId = subsection.Id;
                        
                        section.subSection.Add(new SiteMapSubSection { subSectionUrl = BL.Sections.VirtualPath(subsection) + ".aspx", article = new List<SiteMapArticle>() });// NOTICE CHANGE HERE
        
                        //Debug.WriteLine(smss[0].subSectionUrl);
        
                        var articles = sa.GetArticlesForSection(websiteId, subSectionId, 10);
                        foreach (var article in articles)
                        {
                            //var sma = new List<SiteMapArticle>();
                            subsection.article.Add(new SiteMapArticle { url = BL.Sections.VirtualPath(subsection) + "/" + article.Code + "-" + UrlEncoding.ArticleEncode(article.Headline) + ".aspx" });// NOTICE CHANGE HERE
        
                            //Debug.WriteLine(sma[0].url);
                        }
                    }
                }
