    private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string id = dt.Rows[e.RowIndex]["Eid"] + "";
            string col = dt.Columns[e.ColumnIndex].ColumnName;
            string data = dgv1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "";
    
            string sql = string.Format("UPDATE `try`.`data` SET `{0}` = '{1}' WHERE Eid = {2};", col, data, id);
    
            using (MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=1234"))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
