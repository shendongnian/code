    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int Hour { get; set; }
        public MyDayOfWeek Days { get; set; }
        public string DaysFriendlyName
        {
             get
             {
                  switch(this.Days)
                  {
                      case MyDayOfWeek.SunTilFir:
                             return "Sunday until Friday ";
                  }
                  return "Horrible Failure!!";
             }
         }
    }
