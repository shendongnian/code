    string strconnection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=bank.mdb";
    
        public void InsertMethod(string inputt, string runningtimee, string kindd)
        {
            try
            {
                OleDbConnection objconnection = new OleDbConnection(strconnection);
                OleDbCommand cmd = new OleDbCommand();
                OleDbCommand objcommand = new OleDbCommand("INSERT INTO Table1" +
                    "(db_account_number,db_name,db_family) " +
                    "VALUES(@txtaccount,@txtname, @txtfamily)", objconnection);
                objcommand.Parameters.AddWithValue("@db_account_number", runningtimee);
                objcommand.Parameters.AddWithValue("@db_name", kindd);
                objcommand.Parameters.AddWithValue("@db_family", inputt);
                objconnection.Open();
                objcommand.ExecuteNonQuery();
                objconnection.Close();
            }
            catch (OleDbException a)
            {
                MessageBox.Show(a.ToString());
            }
                
