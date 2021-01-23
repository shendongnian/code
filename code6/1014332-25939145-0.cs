    public void Load() 
    {
    
        List<PivotViewModel> activityResult = new List<PivotViewModel>();
        MyLinq(db.OMS_Planned_Receipts, db.Periods, "System ForeCast", ref activityResult);
        MyLinq(db.OMS_System_Forecast, db.Periods, "System ForeCast", activityResult);
        //activityResult has unionized result        
    }
    
    private void MyLinq(IEnumerable<MyData> myData, IEnumerable<MyPeriod> periods, string activity, ref IEnumerable<PivotViewModel> unionSet)
    {
        unionSet = unionSet.Union
        (
            myData.Where(p => p.Product == product && p.PeriodID >= StartPeriod && p.PeriodID <= EndPeriod)
            .Join(periods, c => c.PeriodID, o => o.PeriodID, (c, o) => new { c, o })
            .Select(b => new PivotViewModel
            {
                Product = b.c.Product,
                PeriodID = b.c.PeriodID,
                SiteID = b.c.SiteID,
                Value = b.c.Value,
                Activity = activity,
                PeriodStart = b.o.Period_Start,
                PeriodEnd = b.o.Period_End,
                PeriodDescription = b.o.Display
            })
        ).ToList();
    }
