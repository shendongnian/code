    var hlLogs = myObject.Select(someStartDate, someEndDate).ToList();
    if (hlLogs.All(hl => hl.Property1 == null))
    {
        myGridView.Columns["Property1"].Visible = false;
    }
    // Same for Property2, etc.
