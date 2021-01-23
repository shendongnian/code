    protected void lbnChangeDate_Click(object sender, EventArgs e)
    {
    
        PersianCalendar p = new PersianCalendar();
        DateTime date = DateTime.Now;
        
        txtDate.Text = string.Format("{0:0000}/{1:00}/{2:00}",
                        p.GetYear(date),
                        p.GetMonth(date),
                        p.GetDayOfMonth(date));
    
    }
