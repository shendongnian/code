    public class CustomDateRangeAttribute : RangeAttribute
    {
         public CustomDateRangeAttribute()
         {
              base();
              base.Maximum = DateTime.Now.AddDays(1).ToString();
         }
    }
