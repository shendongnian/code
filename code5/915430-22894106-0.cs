	protected void Page_Load(object sender, EventArgs e)
	{
	    lblVenue.Text = Session["roomvalue"] != null ? Session["roomvalue"].ToString() : "";
	    if (!IsPostBack)
	    {
	        DayPilotCalendar1.StartDate = DayPilot.Utils.Week.FirstWorkingDayOfWeek(new DateTime(2014, 04, 03));
	        //DayPilotCalendar1.StartDate = DayPilot.Utils.Week.FirstWorkingDayOfWeek(DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek).Date);
	        DayPilotCalendar1.DataSource = dbGetEvents(DayPilotCalendar1.StartDate, DayPilotCalendar1.Days, lblVenue.Text);
	        DataBind();
	    }
	}
