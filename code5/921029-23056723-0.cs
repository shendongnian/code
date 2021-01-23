    public List<GC_ConversionRateModel> GetConversionRate()
        {
            List<GAVisitorsModel> VisitorsList = GetGAStatisticsReport(model);
            List<GC_OrdersModel> OrdersList = GetOrderReport(model);
            List<GC_ConversionRateModel> TotalConversions = new List<GC_ConversionRateModel>();
            OrdersList.ForEach(o => {
                TotalConversions.Add((from v in VisitorsList
                                     where v.Date == o.Date
                                     select new GC_ConversionRateModel(o.Date, o.TotalOrders / v.Visitors)).FirstOrDefault());
                
            });
            return TotalConversions;
        }
