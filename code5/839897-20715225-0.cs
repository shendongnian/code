    foreach (DataGridViewRow dgRow in dataGridView1.Rows)
    {
        if(dgRow.Cells[0].Value!=null)
        {
        string re =dgRow.Cells[0].Value.ToString();
        string strQuery = "UPDATE unit_master SET unit='"+re+"'";
        SqlCommand scmd = new SqlCommand(strQuery,SqlConn);
        scmd.ExecuteNonQuery();
        }
    }
    SqlConn.Close();
