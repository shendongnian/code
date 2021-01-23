    public interface IEntity
    {
        string Product { get; set; }
        int PeriodID { get; set; }
        object SiteID { get; set; }
        object Value { get; set; }
    }
    public partial class OMS_Planned_Receipt : IEntity // Don't know the exact name of your entity class
    {
    }
    public partial class OMS_System_Forecast : IEntity 
    {
    }
    private static IQueryable<PivotViewModel> SelectObjects(IQueryable<IEntity> source,IQueryable<PeriodEntity> jointSource, string product, int StartPeriod, int EndPeriod)
        {
           return source.Where(p => p.Product == product && p.PeriodID >= StartPeriod && p.PeriodID <= EndPeriod)
              .Join(jointSource, c => c.PeriodID, o => o.PeriodID, (c, o) => new { c, o })
              .Select(b => new PivotViewModel
             {
                 Product = b.c.Product,
                 PeriodID = b.c.PeriodID,
                 SiteID = b.c.SiteID,
                 Value = b.c.Value,
                 Activity = "System Forecast",
                 PeriodStart = b.o.Period_Start,
                 PeriodEnd = b.o.Period_End,
                 PeriodDescription = b.o.Display
             });
        }
