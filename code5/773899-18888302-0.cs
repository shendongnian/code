    var groups = tblRoooms.AsEnumerable()
        .GroupBy(r => new{ Adults = r.Field<int>("Adults"), Child = r.Field<int>("Child") });
    
    var tblRooomsCopy = tblRoooms.Clone();  // creates an empty clone of the table
    foreach(var grp in groups)
    {
        int roomCount = grp.Sum(r => r.Field<int>("Roomcount"));
        DataRow row = tblRooomsCopy.Rows.Add();
        row.SetField("RoomNo", grp.First().Field<int>("RoomNo"));
        row.SetField("Roomcount", roomCount);
        row.SetField("Adults", grp.Key.Adults);
        row.SetField("Child", grp.Key.Child);
    }
