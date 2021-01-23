    public class DayVM
    {
      public Day Day { get; set; }
      public bool IsSelected { get; set; }
    }
    public class WeekVM
    {
      public WeekVM()
      {
        Days = new List<DayVM>();
        Days.Add(new DayVM() { Day = Day.Sunday });
        Days.Add(new DayVM() { Day = Day.Monday });
        .. etc
      }
      public List<DayVM> Days { get; set; }
    }
    public class ScheduleViewModel
    {
      public ScheduleViewModel()
      {
        Weeks = new List<WeekVM>();
        Weeks.Add(new WeekVM());
        .... etc
      }
      public int PatientId { get; set; }          
      public List<WeekVM> Weeks { get; set;}          
    }
