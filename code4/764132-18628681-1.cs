     protected void calendar_DayRender(object sender, DayRenderEventArgs e)
        {
            var day = e.Day.Date.ToString("M/d/yyyy");
            HolidayList = Getholiday();
            if (HolidayList[day] != null)
                e.Cell.ForeColor = System.Drawing.Color.Red;
        }
