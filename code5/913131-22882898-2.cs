    private static DataTable dbGetEvents(DateTime start, int days)
    {
        string constr = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ConnectionString;
        SqlDataAdapter da = new SqlDataAdapter("SELECT ID, PURPOSE, [START_DATE], [END_DATE] FROM [Schedule]  WHERE NOT (([END_DATE] <= @start) OR ([START_DATE] >= @end))", constr);
        da.SelectCommand.Parameters.AddWithValue("start", start);
        da.SelectCommand.Parameters.AddWithValue("end", start.AddDays(days));
        DataTable dt = new DataTable();
        da.Fill(dt);
    
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["YourConcatDateColumn"] = CombineDateAndTime(dt.Rows[i]["Date"], dt.Rows[i]["Time"]);
        }
    
        return dt;
    }
    
    public static DateTime CombineDateAndTime(object date, object time)
    {
        if (date == null)
        {
            // Add some logic for this scenario. Here are 2 examples:
            //throw new ArgumentNullException("date");
            //date = DateTime.MaxValue;
        }
        if (time == null)
        {
            // Add some logic for this scenario.
            //throw new ArgumentNullException("time");
            //time = 0;
        }
    
        DateTime dt = Convert.ToDateTime(date);
        float hoursAndMinutes = Convert.ToInt32(time);
    
        return CombineDateAndTime(dt, hoursAndMinutes);
    }
    public static DateTime CombineDateAndTime(DateTime date, float time)
    {
        int hours = Convert.ToInt32(Math.Round((decimal)time / 100, MidpointRounding.AwayFromZero));
        float remainder = time - (hours * 100);
        int minutes = Convert.ToInt32(Math.Round((decimal)remainder, MidpointRounding.AwayFromZero));
        return date.AddHours(hours).AddMinutes(minutes);
    }
