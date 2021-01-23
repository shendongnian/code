    public class DailyChart: IChart
    {
     /***/
      public DailyChart(chartControl, Id)
      {
        chartControl.CustomDraw += new CustomDrawEvent(/**/);
      }
      public Unsubscribe()
      {
        chartControl.CustomDraw -= new CustomDrawEvent(/**/);
      }
    }
    
    public class WeeklyChart: IChart
    {
      public WeeklyChart(chartControl, Id)
      {
       chartControl.CustomDraw += CustomDrawEvent(/**/);
      }
      public Unsubscribe()
      {
        chartControl.CustomDraw -= new CustomDrawEvent(/**/);
      }
    }
