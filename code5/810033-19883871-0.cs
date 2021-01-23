    string insert_sql = "INSERT INTO PLODINY(PLODINA,CENAZAQ,MJ)VALUES(@PLODINA,@CENAZAQ,@MJ)";
    SqlCommand sqlcom = spojeni.CreateCommand();
    sqlcom.CommandText = insert_sql;
    sqlcom.Transaction = sqlTrans;
    sqlcom.Parameters.Add("@PLODINA");
    sqlcom.Parameters.Add("@CENAZAQ");
    sqlcom.Parameters.Add("@MJ");
    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        sqlcom.Parameters[0].Value = row.Cells["PLODINA"].Value;
        sqlcom.Parameters[1].Value = row.Cells["CENAZAQ"].Value;
        sqlcom.Parameters[2].Value = row.Cells["MJ"].Value;
        sqlcom.ExecuteNonQuery();
    }
    sqlTrans.Commit();
    sqlcom.Dispose();
