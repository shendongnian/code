    DataTable dt = ds.Tables[0].Clone();
    var colToTake = new[] { "Col1", "Col3", "Col7", "Col15", "Col19" };
    var colsToRemove = dt.Columns.Cast<DataColumn>()
        .Where(c => !colToTake.Contains(c.ColumnName));
    foreach (DataColumn colToRemove in colsToRemove)
        dt.Columns.Remove(colToRemove);
