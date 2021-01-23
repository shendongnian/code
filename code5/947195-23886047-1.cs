    DataTable dataTable = new DataTable();
    dataTable.Columns.Add("", typeof(double));
    dataTable.Columns[0].Expression = "(1/3)*1.00";
    DataRow r = dataTable.NewRow();
    dataTable.Rows.Add(r);
    double result = (double)dataTable.Rows[0][0];
