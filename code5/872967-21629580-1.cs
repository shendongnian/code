    var idGroups = task
        .Where(t => !String.IsNullOrWhiteSpace(t.AssignedTo))
        .GroupBy(t => t.Id);
    foreach (var idGroup in idGroups)
    {
        var row = dt.NewRow();
        foreach (Task t in idGroup)
        {
            if (t.AssignedTo == "Person1")
                row.SetField("Column1", t.Id.ToString());
            else if(t.AssignedTo == "Person2")
                row.SetField("Column2", t.Id.ToString());
            else if (t.AssignedTo == "Person3")
                row.SetField("Column3", t.Id.ToString());
            else if (t.AssignedTo == "Person4")
                row.SetField("Column4", t.Id.ToString());
            else if (t.AssignedTo == "Person5")
                row.SetField("Column5", t.Id.ToString());
        }
        dt.Rows.Add(row);
    }
