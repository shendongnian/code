        bool con = true;
        try
        {
            OleDbConnection Connection;
            Connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" +
                                             Server.MapPath("~/db.mdb"));
            Connection.Open();
            OleDbCommand Command1, Command2;
            Command1 = new OleDbCommand("SELECT d1 FROM Table1 WHERE ID = 1", Connection);
            Command2 = new OleDbCommand("SELECT d1 FROM Table1 WHERE ID = 2", Connection);
            try
            {
                var1 = (int)Command1.ExecuteScalar();
                var2 = (int)Command2.ExecuteScalar();
            }
            catch
            {
                con = false;
            }
            finally
            {
                Command1.Dispose();
                Command2.Dispose();
                Connection.Close();
            }
        }
        catch
        {
            con = false;
        }
        finally
        {
            if (!con)
            {
                //put your static value here
                var1 = 1;
                var2 = 2;
            }
        }
