    while (reader2.Read())
    {
        DateTime dTest = Convert.ToDateTime(reader2["XData"]);
        TimePointData newPoint = new TimePointData()
            {
            date = EpochTime(dTest) ,
            value = Convert.ToDecimal(reader2["YData"])
            };
        Series.data.Add(newPoint);
    }
