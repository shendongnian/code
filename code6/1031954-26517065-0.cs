        DataSet dataSet = new DataSet();
        DataTable dataTable = new DataTable();
        dataTable.TableName = "Managers";
        dataTable.Columns.Add(new DataColumn("Role"));
        dataTable.Columns.Add(new DataColumn("Who"));
        DataRow dataRow = dataTable.NewRow();
        dataRow[0] = "Singer";
        dataRow[1] = "Johnny Cash";
        dataTable.Rows.Add(dataRow);
        dataRow = dataTable.NewRow();
        dataRow[0] = "Banjo guy";
        dataRow[1] = "Cleetus Smith";
        dataTable.Rows.Add(dataRow);
        
        dataSet.Tables.Add(dataTable);
        String thisGuyIs = "Banjo guy";
        String hisNameIs = "This is our guy: {0}";
        DataRow[] foundRows;
        foundRows = dataSet.Tables["Managers"].Select("Role = '" + thisGuyIs + "'");
                
        if (foundRows.Count() == 1) {
            hisNameIs = String.Format(hisNameIs, foundRows[0]["Who"].ToString());
        }
