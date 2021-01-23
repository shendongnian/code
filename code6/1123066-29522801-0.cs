    public class WorkweekSummary
    {
        public WorkweekSummary()
        {
            MoneyMadeOnDay = new Dictionary<DayOfWeek, double>();
        }
        public int DaysWorked { get{ return MoneyMadeOnDay.Count; } 
        public Dictionary<DayOfWeek, double> MoneyMadeOnDay{ get; private set; }
    }
    var workweekSummaries = new WorkweekSummary[4];
