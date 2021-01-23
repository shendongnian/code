    string result;
        public string autoFill(string Tabel, string naamTxtbox)
        {
            try
            {
                result = "";
                int getIndexKlanten;
                getIndexKlanten = (acsc.IndexOf(naamtxtbox));// < 0) ? -1 : acsc.IndexOf(naamtxtbox);
                if (getIndexKlanten > -1)
                {
                db.cmd.Connection = db.connection;
                db.connection.Open();
                db.cmd.CommandText = "SELECT * " +
                "FROM klant " +
                "WHERE klantnr = ?";
                db.cmd.Parameters.Add(new OleDbParameter("1", _listklantnr[getIndexKlanten].klantnr.ToString()));
                OleDbDataReader dataReader;
                dataReader = db.cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                        klantresult = dataReader[tabel].ToString();   
                }
                dataReader.Close();
                db.cmd.Parameters.Clear();
                db.connection.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return klantresult;
        }
