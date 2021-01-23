    FormDataSet = woutil.GetDataSet;
    dgComments.AutoGenerateColumns = false;
    dgComments.DataSource = FormDataSet.Tables["COMMENT"];
    foreach(DataColumn col in FormDataSet.Tables["COMMENT"].Columns)
    {
        dgComments.Add(col.ColumnName, col.ColumnName);
    }
