    public static List<DateTime> list = new List<DateTime>();
    
    protected void calDate_DayRender(object sender, DayRenderEventArgs e)
    {
            if (e.Day.IsSelected == true)
            {
                list.Add(e.Day.Date);
                e.Cell.BackColor = Color.Orange;
            }
            Session["SelectedDates"] = list;
    }
    
    
    protected void calDate_SelectionChanged(object sender, EventArgs e)
    {
            if (Session["SelectedDates"] != null)
            {
                List<DateTime> newList = (List<DateTime>)Session["SelectedDates"];
                foreach (DateTime dt in newList)
                {
                    calDate.SelectedDates.Add(dt);
                }
                list.Clear();
            }
    }
