        public void showTeam()
        {
            //getting data from database and show it in GridView
            SqlCommand com = new SqlCommand("SELECT [Team_ID],[Team_Age],[Team_Birthday]", con);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dats = new DataSet();
            da.SelectCommand = com;
            da.Fill(dats, "Team_Info");
            dataGridViewX1.DataSource = dats.Tables["Team_Info"];
            //the caculation start from here
            DateTime brithday;
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                brithday = (DateTime)dataGridViewX1[2, i].Value;
                TimeSpan age = DateTime.Today - brithday;
                dataGridViewX1[1, i].Value = age.Days / 365;
            }
        }
