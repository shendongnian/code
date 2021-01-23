     var data = db.ProjectSetups.ToList();
         data = data.Select(c => new ProjectSetup
                            {
                                ProjectId = c.ProjectId,
                                Name = c.Name,
                                NameArabic = c.NameArabic,
                                StartDate = c.StartDate,
                                EndDate = c.EndDate,
                                Date = c.Date,
                                StringType = (c.Type.ToInt32() == 1 ? "Development" : "Rental").ToString(),
                                StringStatus = (c.Status == 1 ? "InProgress" :
                                c.Status == 2 ? "Completed" :
                                c.Status == 3 ? "Dividend" : "Closed"),
                                LandArea = c.LandArea,
                                SaleAmount = c.SaleAmount
    
                            }).ToList();
