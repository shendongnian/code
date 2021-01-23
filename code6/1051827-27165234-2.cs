    using(SqlCeCommand cmd = Login.sqlConn.CreateCommand())
    {
       cmd.CommandText = "INSERT INTO tbl_AStatus ([Asset Status],Remarks) VALUES (@a, @b)";
       cmd.Parameters.Add("@a", SqlDbType.NVarChar).Value = txtAssetStatus.Text;
       cmd.Parameters.Add("@b", SqlDbType.NVarChar).Value = txtRemarks.Text;
       // I assume your column types are NVarChar
       Login.sqlConn.Open();
       int a = cmd.ExecuteNonQuery();
       MessageBox.Show(a.ToString());
    }
