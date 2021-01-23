    if (calendars != null && calendars.Rows.Count > 0)
    {
        ButtonEx buttonCalendar = null;
        Int64 App_CalendarID = 0;
        String Title = "";
        Drawable icon = null;
        icon = Resources.GetDrawable(Resource.Drawable.image_calendar_light);
        foreach (DataRow row in calendars.Rows)
        {
            App_CalendarID = Convert.ToInt64(row["App_CalendarID"]);
            Title = Convert.ToString(row["Title"]);
            buttonCalendar = new ButtonEx(layoutFeatureBody.Context)
            {
                Text = Title,
                Tag = App_CalendarID,
                Image = icon,
                TextColor = Color.White,
                TextSize = 14,
            };
            layoutFeatureBody.AddView(buttonCalendar);
            buttonCalendar.Touch += buttonCalendar_Touch;
        }
    }
