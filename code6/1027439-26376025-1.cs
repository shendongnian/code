    string str = "VALVE,GATE,SH_NAME:VLV,GATE,VLV_NOM_SIZE:4-1/16IN";
    string[] Rows = str.Split(',');
    dataGridView1.Columns.Add("Column1", "Column1");
    dataGridView1.Columns.Add("Column2", "Column2");
    foreach (string AddRow in Rows)
    {
       string[] Row = AddRow.Split(':');
       dataGridView1.Rows.Add(Row);
    }
