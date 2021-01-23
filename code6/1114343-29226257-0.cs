        public DataTable GetDates()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Date", typeof(DateTime));
            int year = Convert.ToInt32(ddyear.SelectedItem.Value);
            int month = Convert.ToInt32(ddmonth.SelectedItem.Value);
            int daysInMonth = DateTime.DaysInMonth(year, month);
            for (int i = 0; i < daysInMonth; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Date"] = new DateTime(year, month, i + 1);
                dt.Rows.Add(dr);
            }
            return dt;
        }
     
