      static bool detectIfRepeated(OleDbConnection cnx, String username)
        {
            DataTable res = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM UserPassword", cnx);
            adp.Fill(res);
            int i = 0;
            bool found = false;
            String user = Convert.ToString(res.Rows[i]["User"]);
            while (i < res.Rows.Count && !found)
            {
                if (user == username)
                {
                    found = true;
                    MessageBox.Show("The username is already taken. Choose a different one.");
                     
                }
                else
                    i++;
            }
            return found
        }
