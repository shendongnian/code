                   var filtro = (from r in newTable.AsEnumerable()
                                 join anuncios in adslist.AsEnumerable() on r.Field<string>("ADGROUPID") equals anuncios.id.ToString() into grouping
                                 from d in grouping.DefaultIfEmpty()
                                 select new
                                     {
                                         
                                         Campaign = r.Field<string>("CAMPAIGN"),
                                         AdName = d.name,
                                         Clicks = r.Field<string>("CLICKS"),
                                         TotalConv = r.Field<string>("TotalConvValue"),
                                         Cost = r.Field<string>("Cost"),
                                         CostConvClick = r.Field<string>("CostConvertedClick"),
                                         keyword = r.Field<string>("KEYWORD"),
                                         Counting = grouping.Count()
                                     }).ToList().OrderByDescending(t => t.Clicks); 
    
