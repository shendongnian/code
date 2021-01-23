    var returnNews = reportResult.Select(n =>
                {
                    var createdBy = allUsersInfoForReport.FirstOrDefault(u => u.ID == n.CreatedBy);
                    var publishedBy = allUsersInfoForReport.FirstOrDefault(u => u.ID == n.Publishedby);
                    var modifiedBy = allUsersInfoForReport.FirstOrDefault(u => u.ID == n.LastModifiedBy);
    
                    newsViewCountEntity = newsViewCountCollection.FirstOrDefault(nv => nv.News_ID == n.ID);
                    newsCommentsCount = newsCommentsCollection.Count(s => s == n.ID);
    
                    return new ReportItemViewModel()
                    {
                        ID = n.ID,
    
                        AddedBy = createdBy != null ? createdBy.UserName : "",
                        UserSectionName = createdBy != null ? createdBy.RelatedSectionName : "",
                        PublishedBy = publishedBy != null ? publishedBy.UserName : "",
                        LastModifiedBy = modifiedBy != null ? modifiedBy.UserName : "",
                    }
    });
