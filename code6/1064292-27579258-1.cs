        var testString = "היי"; // Do be aware that Visual Studio displays Hebrew text right-to-left, so the actual string is reversed from what you see.
        using (OleDbConnection conn = Connect())
        {
            conn.Open();
            using (OleDbCommand com = conn.CreateCommand())
            {
                // OleDbCommand com = new OleDbCommand("Insert into mytable values ('היי')", conn);
                com.CommandType = CommandType.Text;
                com.CommandText = "Insert into mytable values (?)";
                com.Parameters.Add(new OleDbParameter { OleDbType = OleDbType.VarWChar }).Value = testString;
                com.ExecuteNonQuery();
            }
        }
