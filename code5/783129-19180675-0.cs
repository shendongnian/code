    foreach (var resultSet in globalResultSet)
    {
        for(var i=0; i < resultSet.Length; i++)
        {
            resultSet[i].Fees.ToList().Sort(new Comparison<FeesType>((x, y) => DateTime.Compare(x.DueDate, y.DueDate)));
        }
    }
