    public void make_cbDispatch()           
    {     
            string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;"
                                        + "Data Source=I:\\Projects\\project.accdb;"
                                        + "Persist Security Info=False;";
            string qr1 = "SELECT DISTINCT object "
                                        + "FROM tList "
                                        + "ORDER BY object ";
            OleDbConnection con = new OleDbConnection(ConnectionString);
            OleDbCommand cmd1 = new OleDbCommand(qr1, con);
            con.Open();
             OleDbDataReader dr1 = cmd1.ExecuteReader();
            cbDispatch.Items.Clear();
            while (dr1.Read())
            {
                cbDispatch.Items.Add(dr1[0].ToString());
            }
            con.Close();
    }
