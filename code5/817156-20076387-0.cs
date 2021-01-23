    protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
	   if (user == someRestrictedUser && e.NewDate.Month == DateTime.Now.Month) {
	      Calendar1.PrevMonthText = string.Empty;
	   } else {
	      Calendar1.PrevMonthText = "&lt;";
  	   }
    }
