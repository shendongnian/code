    SqlConn=new SqlConnection("/*your connection string*/");
    foreach (DataGridViewRow dgRow in dataGridView1.Rows)
    {
        if(dgRow.Cells[0].Value!=null)
        {
           string re =dgRow.Cells[0].Value.ToString();
           string strQuery = "UPDATE unit_master SET unit=@unit";
           SqlCommand scmd = new SqlCommand(strQuery,SqlConn);
           scmd.Parameters.AddWithValue("@unit",unit);
           scmd.ExecuteNonQuery();
        }
    }
    SqlConn.Close();
