    string date = "2014-03-17";
    DateTime d1 = DateTime.Parse(date);
    DateTime d2 = DateTime.Now.Date;
    if (d1.Equals(d2))
    {
        //Do something
    }
