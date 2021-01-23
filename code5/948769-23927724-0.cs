    if(txtMeetingTime.Text.Length > 0)
    {
        DateTime meetingTime;
        DateTime.TryParseExact(txtMeetTime.Text, new string[] { "H:mm" },
              System.Globalization.CultureInfo.InvariantCulture,
              System.Globalization.DateTimeStyles.None,
              out meetingTime);
        cmd.Parameters.AddWithValue("@updateTime", meetingTime);
    }
    else
    {
        cmd.Parameters.Add("@updateTime",SqlDbType.DateTime).Value = DBNull.Value;
    }
