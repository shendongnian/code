    OleDbDataReader dReader;
    string cmdText="SELECT [Code], [Description] FROM [Data] WHERE Code=@Code"
    using(OleDbConnection conn = new OleDbConnection(connectionString))
    using(OleDbCommand cmd = new OleDbCommand(cmdText, conn))
    {
        conn.Open();
        cmd.Parameters.Add(new OleDbParameter("@Code", OleDbType.VarChar, 200, "Code"));
        cmd.Parameters["@Code"].Value = textBoxCodeContainer[0][y].Text;
        using(OleDbDFataReader dReader = cmd.ExecuteReader())
        {
            AutoCompleteStringCollection codesCollection = new AutoCompleteStringCollection();
            while (dReader.Read())
            {
                string numString = dReader[1].ToString());
                codesCollection.Add(numString);
            }
        }
    }
