    if (row[0] != System.DBNull.Value))
    {
        EmployeeID = Convert.ToInt32(row[0]);
    }
    else
    {
     EmployeeID = somethingelse;
    }
