    foreach (string column in node.ColumnNames)
    {
         //do something helpful with each one
         string value = ValidationHelper.GetString(node.GetValue(column), string.Empty);
    }
