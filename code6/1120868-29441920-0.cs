    string dateTime = "01 April 2015 Wednesday 16:23";
    DateTime time1 = Convert.ToDateTime(dateTime);
    
    if (DateTime.Compare(DateTime.Now, time1) == 1 &&  // DateTime.Now > time1
        DateTime.Compare(time1, DateTime.Today.AddDays((int)-7)) == 1 // time1 >= DateTime.Now-7days
        )
    {
        @("True.")
    }
    else
    {
        @("False.")
    }
