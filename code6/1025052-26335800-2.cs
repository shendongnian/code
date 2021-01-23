    DataTable dt = new DataTable();
    for (int i = 1; i < dgv.Columns.Count + 1; i++)
    {
        DataColumn column = new DataColumn(dgv.Columns[i - 1].HeaderText);
        dt.Columns.Add(column);
    }
    int columnCount = dgv.Columns.Count;
    foreach (DataGridViewRow dr in dgv.Rows)
    {
        DataRow dataRow = dt.NewRow();
        for (int i = 0; i < columnCount; i++)
        {
            //returns checkboxes and dropdowns as string with .value..... nearly got it
            dataRow[i] = dr.Cells[i].Value;
        }
        dt.Rows.Add(dataRow);
    }
    DataSet ds = new DataSet();
    ds.Tables.Add(dt);
    XmlTextWriter xmlSave = new XmlTextWriter(@"c:/older/DGVXML.xml", Encoding.UTF8);
               
    ds.WriteXml(xmlSave);
    xmlSave.Close();
