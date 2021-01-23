    var siteMapSection = new List<SiteMapSection>();
            DL.SectionArticle sa = new NewsFeed.BusinessTier.DataAccessLayer.SectionArticle();
    
            foreach (BE.Section section in BL.Sections.Find(websiteId, parentSectionId))
            {
                int sectionId = section.Id;
                var siteMap=new SiteMapSection { sectionUrl = BL.Sections.VirtualPath(section) + ".aspx" };
                
     
                Debug.WriteLine(siteMap.sectionUrl);
    	    var smss = new List<SiteMapSubSection>();
                foreach (BE.Section subsection in BL.Sections.Find(websiteId, sectionId))
                {
                    int subSectionId = subsection.Id;
                    var sms=new SiteMapSubSection { subSectionUrl = BL.Sections.VirtualPath(subsection) + ".aspx" };
    		Debug.WriteLine(smss[0].subSectionUrl);                
    		
    
                    
    		var sma = new List<SiteMapArticle>();
                    var articles = sa.GetArticlesForSection(websiteId, subSectionId, 10);
                    foreach (var article in articles)
                    {
                        var sm= new SiteMapArticle { url = BL.Sections.VirtualPath(subsection) + "/" + article.Code + "-" + 			UrlEncoding.ArticleEncode(article.Headline) + ".aspx" };  
                        sma.Add(sm);
    
                        Debug.WriteLine(sm.url);
                    }
    		sms.article=sma;
    		smss.Add(sms);
                }
    		siteMap.subSection=smss;
    		siteMapSection.Add(siteMap);
            }
