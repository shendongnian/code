    DateTime startDate;
    DateTime endDate;
    var isValidStartDate = DateTime.TryParse(txtStartDate.Text, out startDate);
    var isValidEndDate = DateTime.TryParse(txtEndDate.Text, out endDate);
    if (isValidStartDate && isValidEndDate)
    {
        var rowArray = dt.Select(
            string.Format("DOB >= #{0}# AND DOB <= #{1}#", startDate, endDate));
        // do something with rowArray
    }
    else
    {
        // uh-oh...
    }
