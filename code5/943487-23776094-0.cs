    public class TimesheetModel
    {
        public TimesheetModel()
        {
            this.Activities = new List<ActivityModel>();
        }
        public int ID { get; set; }
        public int UserID { get; set; }
        public List<ActivityModel> Activities { get; set; }  
        public DateTime Day { get; set; }
    }
    public class ActivityModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Hours { get; set; }
    }
