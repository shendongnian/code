    using (SqlDataAdapter da = new SqlDataAdapter(cmdSchedule))
    {
        DataSet ds = new DataSet();
        da.Fill(ds);
    
        for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
        {
            var row = dt.Tables[0].Rows[i];
    
            string ReturnDay = row["Day"].ToString();
            string StartingTime = row["StartTime"].ToString();
            string EndingTime = row["EndTime"].ToString();
    
            if (ReturnDay.Trim().Equals("Monday"))
            {
                if (StartingTime.Trim().Equals("10:00") &&
                    EndingTime.Trim().Equals("12:00"))
                {
                    var btn = this.Controls.FindControl(
                        string.Format("btn{0}", i + 1)) as Button;
                    btn.BackColor = Color.Red;
                }
            }
        }
    }
