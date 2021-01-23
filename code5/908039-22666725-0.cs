    var tableC = new DataTable();
    tableC.Columns.Add(new DataColumn("ID"));
    tableC.Columns.Add(new DataColumn("Name"));
    tableC.Columns.Add(new DataColumn("TableAValue1"));
    tableC.Columns.Add(new DataColumn("TableBValue1"));
    tableC.Columns.Add(new DataColumn("DiffValue1"));
    foreach (DataRow rowA in tableA.Rows)
    {
        foreach (DataRow rowB in tableB.Rows)
        {
            if (Convert.ToInt32(rowA["ID"]) == Convert.ToInt32(rowB["ID"]) &&
                rowA["Name"].ToString() == rowB["Name"].ToString() &&
                Convert.ToInt32(rowA["Value1"]) != Convert.ToInt32(rowB["Value1"]))
            {
                var newRow = tableC.NewRow();
                newRow["ID"] = rowA["ID"];
                newRow["Name"] = rowA["Name"];
                newRow["TableAValue1"] = rowA["Value1"];
                newRow["TableBValue1"] = rowB["Value1"];
                newRow["DiffValue1"] = Convert.ToInt32(rowA["Value1"]) - Convert.ToInt32(rowB["Value1"]);
                tableC.Rows.Add(newRow);
            }
        }
    }
