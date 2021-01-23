    DataTable table;
    try 
    {
       string expression = string.Format("DateTime > '{0}' and DateTime < '{1}'", abc.Min, abc.Max);
       table = _TrailTable.Select(expression).CopyToDataTable();
    }
    catch(Exception ex)
    {
       table = null;
    }
