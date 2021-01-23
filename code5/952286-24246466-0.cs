    public List<Guid> GetMostPopularArticles()
                {
                    string where = "Where it.TemplateID = {2}TemplateCondition{3} OR it.templateID ={2}SecoundTemplateId{3} ";
                    string CommandText = @"SELECT TOP (100) PERCENT pa.ItemId, it.TemplateID, pa.PageViewCount 
                                                    FROM (SELECT {0}ItemId{1},COUNT(*) AS {0}PageViewCount{1} 
                                                        FROM [lp_analytics].[dbo].[Pages] 
                                                            GROUP BY {0}ItemId{1}) AS pa 
                                                                INNER JOIN  [lp_master].[dbo].[Items] AS it ON  pa.ItemId =  it.ID 
                                                    " + where + " ORDER BY pa.PageViewCount DESC";
        
                    string firstTemplateId = ArticlePageItem.TemplateId.ToString().Replace("{", "").Replace("}", "");
                    string secoundTemplateId = RecipePageItem.TemplateId.ToString().Replace("{", "").Replace("}", "");
                    List<Guid> visitsId = DataAdapterManager.Sql.ReadMany<Guid>(CommandText, reader => DataAdapterManager.Sql.GetGuid(0, reader), new object[] { "TemplateCondition", firstTemplateId, "SecoundTemplateId", secoundTemplateId });
                    return visitsId;
                }
