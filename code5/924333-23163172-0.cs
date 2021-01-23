                try
            {
                //Defanitions  
                string myConnrction = "*********;port=3306;username=******;password=******";
                MySqlConnection myConn = new MySqlConnection(myConnrction);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                myDataAdapter.SelectCommand = new MySqlCommand(" select * sql337069.Youtube;", myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                DataSet ds = new DataSet();
                string Query = "select * from sql337069.Youtube ;";
                MySqlCommand cmdDataBase = new MySqlCommand(Query, myConn);
                MySqlDataReader myreader;
                //Defanitions  
                myConn.Open();
                myreader = cmdDataBase.ExecuteReader();
                while (myreader.Read())
                {
                    string sName = myreader.GetString("Video2_Refresh");
                    Video2_Refresh.Text = sName;
                }
                MessageBox.Show("Working");
            }
            catch
            {
                MessageBox.Show("Null");
            }
