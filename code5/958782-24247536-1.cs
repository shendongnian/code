    private DaySelect[] Days = new DaySelect[] 
        {
            new DaySelect() { DayAbbr = "M", DayID = 1, IsSelected = true },
            new DaySelect() { DayAbbr = "T", DayID = 2 },
            new DaySelect() { DayAbbr = "W", DayID = 3 },
            new DaySelect() { DayAbbr = "T", DayID = 4 },
            new DaySelect() { DayAbbr = "F", DayID = 5 },
            new DaySelect() { DayAbbr = "S", DayID = 6 },
            new DaySelect() { DayAbbr = "S", DayID = 7 },
        };
    protected void Page_Load(object sender, EventArgs e)
    {
        rpDaysOfWeek.DataSource = Days;
        if (!Page.IsPostBack)
        {
            rpDaysOfWeek.DataBind();
            gvHoursAttendance.DataSource = CreateWorkHours(Days.Single(d => d.IsSelected).DayID);
            gvHoursAttendance.DataBind();
        }
    }
    protected void DaySelect_Command(object sender, CommandEventArgs e)
    {
        int dayId = Convert.ToInt32(e.CommandArgument);
        foreach (DaySelect day in Days)
        {
            day.IsSelected = day.DayID == dayId;
        }
        rpDaysOfWeek.DataBind();
        gvHoursAttendance.DataSource = CreateWorkHours(Days.Single(d => d.IsSelected).DayID);
        gvHoursAttendance.DataBind();
    }
    public WorkHour[] CreateWorkHours(int dayId)
    {
        return new WorkHour[]
            {
                new WorkHour() { ActualCount = dayId, ExpectedCount = dayId, Hour = 0 },
                new WorkHour() { ActualCount = dayId, ExpectedCount = dayId, Hour = 1 },
                new WorkHour() { ActualCount = dayId, ExpectedCount = dayId, Hour = 2 },
                new WorkHour() { ActualCount = dayId, ExpectedCount = dayId, Hour = 3 },
                new WorkHour() { ActualCount = dayId + 1, ExpectedCount = dayId, Hour = 4 },
                new WorkHour() { ActualCount = dayId + 1, ExpectedCount = dayId, Hour = 5 },
                new WorkHour() { ActualCount = dayId + 1, ExpectedCount = dayId, Hour = 6 },
                new WorkHour() { ActualCount = dayId + 1, ExpectedCount = dayId, Hour = 7 },
                new WorkHour() { ActualCount = dayId, ExpectedCount = dayId + 1, Hour = 8 },
                new WorkHour() { ActualCount = dayId, ExpectedCount = dayId + 1, Hour = 9 },
                new WorkHour() { ActualCount = dayId, ExpectedCount = dayId + 1, Hour = 10 },
                new WorkHour() { ActualCount = dayId, ExpectedCount = dayId + 1, Hour = 11 },
                new WorkHour() { ActualCount = dayId + 1, ExpectedCount = dayId + 1, Hour = 12 },
                new WorkHour() { ActualCount = dayId + 1, ExpectedCount = dayId + 1, Hour = 13 },
                new WorkHour() { ActualCount = dayId + 1, ExpectedCount = dayId + 1, Hour = 14 },
                new WorkHour() { ActualCount = dayId + 1, ExpectedCount = dayId + 1, Hour = 15 },
                new WorkHour() { ActualCount = dayId * 2, ExpectedCount = dayId + 1, Hour = 16 },
                new WorkHour() { ActualCount = dayId * 2, ExpectedCount = dayId + 1, Hour = 17 },
                new WorkHour() { ActualCount = dayId * 2, ExpectedCount = dayId + 1, Hour = 18 },
                new WorkHour() { ActualCount = dayId * 2, ExpectedCount = dayId + 1, Hour = 19 },
                new WorkHour() { ActualCount = dayId - 1, ExpectedCount = dayId * 2, Hour = 20 },
                new WorkHour() { ActualCount = dayId - 1, ExpectedCount = dayId * 2, Hour = 21 },
                new WorkHour() { ActualCount = dayId - 1, ExpectedCount = dayId * 2, Hour = 22 },
                new WorkHour() { ActualCount = dayId - 1, ExpectedCount = dayId * 2, Hour = 23 },
            };
    }
    public class DaySelect
    {
        public string DayAbbr { get; set; }
        public int DayID { get; set; }
        public bool IsSelected { get; set; }
    }
    public class WorkHour
    {
        public int Hour { get; set; }
        public int ExpectedCount { get; set; }
        public int ActualCount { get; set; }
    }
