    protected void btnUpload_Click(object sender, EventArgs e)
    {
        using (var con = new OleDbConnection())
        {
            con.ConnectionString =
                    @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                    @"Data Source=C:\__tmp\staffDb.accdb;";
            con.Open();
            using (var cmd = new OleDbCommand())
            {
                cmd.Connection = con;
                cmd.CommandText =
                        "UPDATE STAFF SET Resume=? " +
                        "WHERE StaffID=?";
                cmd.Parameters.AddWithValue("?", FileUpload1.FileBytes);
                cmd.Parameters.AddWithValue("?", 1);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }
    }
