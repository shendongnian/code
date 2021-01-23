     protected void calendar_DayRender(object sender, DayRenderEventArgs e)
        {
            var day = e.Day.Date.ToString("M/d/yyyy");
            Hashtable holiday = new Hashtable();
            if (HolidayList[day] != null)
                e.Cell.ForeColor = System.Drawing.Color.Red;
        }
