    OleDbDataAdapter Data = new OleDbDataAdapter(command.CommandText, conn);
    
    DataSet ds = new DataSet();
    
    Data.Fill(ds);
    foreach (DataRow row in ds.Tables[0].Rows)
    {
         DataGridViewRow NewRow = (DataGridViewRow)dataGridViewGroups.Rows[0].Clone();
         NewRow.Cells[0].Value = row["CodeGroup"].ToString();
         NewRow.Cells[1].Value = row["NameGroup"].ToString();
         dataGridViewGroups.Rows.Add(NewRow);
    }
    
    conn.Close();//You might be able to add this under the Data.Fill()
