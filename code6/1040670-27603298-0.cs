     using (SPSite site = new SPSite(siteUrl))
                {
                        using (var qRequest = new KeywordQuery(site)
                        {
                            QueryText = "MobilePhone:*" +"123" , 
                            EnableQueryRules = true,
                            EnableSorting = false, 
                            SourceId = new Guid("Enter here Result Source Guid"),
                            TrimDuplicates = false
                        })
                        { 
                            //Get properties you want here
                            qRequest.SelectProperties.Add("FirstName");
                            qRequest.SelectProperties.Add("LastName");
                            
                            SearchExecutor e = new SearchExecutor();
                            ResultTableCollection rt = e.ExecuteQuery(qRequest);
                            var tab = rt.Filter("TableType", KnownTableTypes.RelevantResults);
                            var result = tab.FirstOrDefault();
                            DataTable resultTable = result.Table;
                        }
    }
