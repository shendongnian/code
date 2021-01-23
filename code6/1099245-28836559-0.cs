            myconn.Open();
            MySqlCommand cmdDataBase1 = new MySqlCommand("select * FROM quizdb.aeasy order by rand();", myconn);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase1;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                ds.Tables.Add(dt);
                sda.Fill(dt);
                foreach (DataRow myRow in dt.Rows)
                {
                    label1.Text = myRow[1].ToString();
                    radioButton1.Text = myRow[2].ToString();
                    radioButton2.Text = myRow[3].ToString();
                    radioButton3.Text = myRow[4].ToString();
                    radioButton4.Text = myRow[5].ToString();
                    //label1.Text = myRow[6].ToString();
                }
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.Message);
            }
            myconn.Close();
        }
