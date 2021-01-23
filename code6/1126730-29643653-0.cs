        try
        {
            OleDbConnection Connection;
            Connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" +
                                             Server.MapPath("~/db.mdb"));
            OleDbCommand Command1, Command2;
            Command1 = new OleDbCommand("SELECT d1 FROM Table1 WHERE ID = 1", Connection);
            Command2 = new OleDbCommand("SELECT d1 FROM Table1 WHERE ID = 2", Connection);
            Connection.Open();
            var1 = (int)Command1.ExecuteScalar();
            var2 = (int)Command2.ExecuteScalar();
            Connection.Close();
        }
        catch
        {
            //put your static value here
            var1 = 1;
            val2 = 2;
        }
