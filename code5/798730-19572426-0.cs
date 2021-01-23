        public void AddToDatabase()
        {
            string cmdText = "insert into Table1 (Vndnbr) Values (?)";
            using(OleDbConnection connection = new OleDbConnection(.....))
            using(OleDbCommand command = new OleDbCommand(cmdText, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@p1", "");
                foreach (string x in Vndnbr)
                {
                     command.Parameters["@p1"].Value = x;
                     command.ExecuteNonQuery();
                 
                }
            }
        }
