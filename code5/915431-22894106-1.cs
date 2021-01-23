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
    
            private DataTable dbGetEvents(DateTime start, int days, string roomValue)
            {
                if (string.IsNullOrWhiteSpace(roomValue))
                    throw new ArgumentNullException("roomValue");
    
                const string sql = @"
    SELECT
        s.ID,
        PURPOSE,
        [START_DATE],
        [END_DATE],
        [START_TIME],
        [END_TIME]
    FROM [Schedule] s
        JOIN [rooms] r ON r.ROOM_CODE = s.ROOM_CODE
    WHERE r.ROOM_TYPE = @SelectedRoomType";
    
                string constr = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ConnectionString;
                SqlDataAdapter da = new SqlDataAdapter(sql, constr);
                da.SelectCommand.Parameters.AddWithValue("@SelectedRoomType", roomValue);
    
                da.SelectCommand.Parameters.AddWithValue("start", start);
                da.SelectCommand.Parameters.AddWithValue("end", start.AddDays(days));
                DataTable dt = new DataTable();
                da.Fill(dt);
    
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["START_DATE"] = CombineDateAndTime(dt.Rows[i]["START_DATE"], dt.Rows[i]["START_TIME"]);
                    dt.Rows[i]["END_DATE"] = CombineDateAndTime(dt.Rows[i]["END_DATE"], dt.Rows[i]["END_TIME"]);
                }
    
                return dt;
            }
