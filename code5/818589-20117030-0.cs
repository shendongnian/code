    DateTime date;
    if (DateTime.TryParse(time, out date))
    {
        TimeSpan diff = date - dt;
            if (diff.TotalMinutes >= 20)
            {
              //Do sommething 
            }
    }
