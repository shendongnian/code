    foreach(var item in allcats)
                {
                    if (model.AllCategories.Select(m => m).Where(x => x.Category == item.Category).ToList().Count == 0) 
                    {
                        if (item.ResultCode == "AP") {
                            model.AllCategories.Add(new ModReportingDM.ReportObjects.AllCategories()
                            {
                                Category = item.Category,
                                AcceptCount = item.Count
                            });
                        }
                        else
                        {
                            model.AllCategories.Add(new ModReportingDM.ReportObjects.AllCategories()
                            {
                                Category = item.Category,
                                RejectCount = item.Count
                            });
                        }
                    }
                    else 
                    {
                        ModReportingDM.ReportObjects.AllCategories x = model.AllCategories.Select(n => n).Where(y => y.Category == item.Category).ToList().First();
                        if (item.ResultCode == "AP") 
                        {
                            x.AcceptCount = item.Count;
                        }
                        else 
                        { 
                            x.RejectCount = item.Count; 
                        }
                   }   
                }
