    Public WeekDayNameComparer<YourObject> : IComparer<yourObject> 
    {
       private string[] WeekDays = {"sunday", "monday", ..."friday"}
       public int Compare(YourObject x, YourObject y) {
          return Array.indexOf(WeekDays, x.WeekDay).CompareTo(Array.indexOf(WeekDays, y.WeekDay));
       }
    }
