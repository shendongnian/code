    // create input data
    var inputData = new DataTable();
    inputData.Columns.Add("ID", typeof (int));
    inputData.Columns.Add("Description", typeof (string));
    inputData.Columns.Add("Model", typeof (string));
    inputData.Columns.Add("Department", typeof (string));
    inputData.Rows.Add(1, "Item1", "Model1", "Department1");
    inputData.Rows.Add(2, "Item2", "Model1", "Department2");
    inputData.Rows.Add(3, "Item3", "Model1", "Department1");
    inputData.Rows.Add(4, "Item4", "Model1", "Department2");
    inputData.AcceptChanges();
    // create output data
    var outputData = new DataSet();
    outputData.Tables.AddRange(
        inputData.AsEnumerable()
                 .GroupBy(row => row.Field<string>("Department"))
                 .Select(rowGroup => {
                                         var departmentTable = inputData.Clone();
                                         departmentTable.TableName = rowGroup.Key;
                                         foreach (var row in rowGroup)
                                             departmentTable.Rows.Add(row.ItemArray);
                                         return departmentTable;
                                     })
                 .ToArray());
    outputData.AcceptChanges();
