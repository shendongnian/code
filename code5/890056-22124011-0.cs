    if (clbGeneral.CheckedIndices.Count != 0)
    {
        try
        {
            foreach (var item in clbGeneral.CheckedItems)
            {
                string sql=string.Format("INSERT INTO transactions (<column names here>) " +
				"SELECT '{0}', '{1}', '{2}', serv_id "+ // add "TOP 1" if you might get more than 1 result and only want to do 1 insert
				"FROM services " +
				"WHERE serv_name='{3}'); ",
				txtDate.Text, dataPnts.SelectedRows[0].Cells[3].Value.ToString(),
				dataProvs.SelectedRows[0].Cells[4].Value.ToString(), item.ToString());
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
    
                MessageBox.Show(clbGeneral.SelectedItem.ToString());
            }
        }
        finally
        {
            con.Close();
        }
    }
