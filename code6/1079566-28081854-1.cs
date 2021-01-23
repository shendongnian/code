    DateTime startTime =Convert.ToDateTime(txtstarttime.Text);
    DateTime endTime = Convert.ToDateTime(txtendtime.Text);
    DateTime startdate=Convert.ToDateTime(txtstartdate.Text);
    DateTime enddate=Convert.ToDateTime(txtenddate.Text);
    if(startTime>endTime)
    {
     TimeSpan span = endTime.Subtract ( startTime );
     if(span!=null)
     {
       string timedifference=Convert.ToString(span.Hours)+" Hours "+Convert.ToString(span.Minutes)+" Minutes "+Convert.ToString(span.Seconds)+" Seconds";
     }
    }
    if(startdate>enddate)
    {
     string datedifference=(enddate- startdate).TotalDays.ToString()+" days";
    }
    if(datedifference!=null&&timedifference!=null)
    {
      txtDuration=datedifference+ timedifference;
    }
