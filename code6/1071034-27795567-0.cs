     DateTime time1 = DateTime.Now;
     DateTime time2 = Convert.ToDateTime("11:00:00 AM");
     DateTime time3 = Convert.ToDateTime("1:00:00 PM");
     if (DateTime.Compare(time1, time3) < 0 && DateTime.Compare(time1, time2) > 0)
     {
     }
