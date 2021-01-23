       List<AdwordsClass> filtro = (from r in newTable.AsEnumerable()
                                       group r by new{ camp=r.Field<string>("CAMPAIGN"), id=r.Field<string>("adgroupid"), keyw= r.Field<string>("KEYWORD")} into grouping
                                      join anuncios in adslist.AsEnumerable() on grouping.FirstOrDefault().Field<string>("ADGROUPID") equals anuncios.id.ToString()
                                                     select new AdwordsClass()
                                      {
                                          CampaignName = grouping.Key.camp,
                                          CampaignId   =  Convert.ToInt64(grouping.FirstOrDefault().Field<string>("CAMPAIGNID")),
                                          AdsGroupID = grouping.Key.id,
                                          KeyWord = grouping.Key.keyw,
                                          AdsGroupName = anuncios.name,
                                          clicks = grouping.FirstOrDefault().Field<string>("CLICKS"),
                                          TotalConv = grouping.FirstOrDefault().Field<string>("TotalConvValue"),
                                          Cost =grouping.FirstOrDefault().Field<string>("Cost"),
                                          CostConvClick =grouping.FirstOrDefault().Field<string>("CostConvertedClick"),
                                          Counting = grouping.Count()
                                      }).ToList().OrderByDescending(t => t.clicks).ToList(); 
