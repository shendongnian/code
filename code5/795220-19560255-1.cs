    try 
    {
        foreach (DataRow row in dt.Rows)
        {
            if (row["TABLE_NAME"].ToString().Contains("$") )
            {
                OleDbCommand cmd = new OleDbCommand(
                  "select * from [" + row["TABLE_NAME"].ToString() + "]", file);
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        cbsheet.Items.Add(row["TABLE_NAME"].ToString());
                    }
                    dr.close();
                }
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("ERROR: "+ex);
    }
