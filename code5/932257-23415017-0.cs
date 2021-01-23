    var cl = new List<CancellationList>();
    var dataTable = new DataTable();
    var toObject = cl.Select(c => new object[] {c.SchemeId, c.EffectiveDate, c.TransactionDate, c.ExpiryDate});
    dataTable.Columns.Add("SchemeId", typeof (int));
    dataTable.Columns.Add("EffectiveDate", typeof (DateTime));
    dataTable.Columns.Add("TransactionDate", typeof(DateTime));
    dataTable.Columns.Add("ExpiryDate", typeof(DateTime));
    foreach (var data in toObject)
    {
        dataTable.Rows.Add(data);
    }
