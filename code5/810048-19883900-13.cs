    string insert_sql = "INSERT INTO PLODINY(PLODINA,CENAZAQ,MJ)VALUES(@PLODINA,@CENAZAQ,@MJ)";
    using(SqlCommand sqlcom = spojeni.CreateCommand())
    {
        sqlcom.CommandText = insert_sql;
        sqlcom.Transaction = sqlTrans;
    
        sqlcom.Parameters.Add("@PLODINA", SqlDbType.NVarChar); //Replace with whatever the correct datatypes are
        sqlcom.Parameters.Add("@CENAZAQ", SqlDbType.NVarChar);
        sqlcom.Parameters.Add("@MJ", SqlDbType.NVarChar);
    
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            sqlcom.Parameters["@PLODINA"] = row.Cells["PLODINA"].Value;
            sqlcom.Parameters["@CENAZAQ"] = row.Cells["CENAZAQ"].Value;
            sqlcom.Parameters["@MJ"] = row.Cells["MJ"].Value;
            sqlcom.ExecuteNonQuery();    
        }
    }
    sqlTrans.Commit();
