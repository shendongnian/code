     private void Save(string hfname, string hlname, string hemail, string hcomment)
        {
            SqlConnection myConn = new SqlConnection(GetConnectionString());
            String sql = "INSERT INTO helpdesk (First_Name, Last_Name, Email, Comments) VALUES " + " (@f_name, @l_name, @email, @comment)";
            SqlCommand cmd = new SqlCommand(sql, myConn);
            ITDBDataset itdbDataSet = new ITDBDataset();
            SqlDataAdapter dataAdapter;
            try
            {
                myConn.Open();
                dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(itdbDataSet);
               
                SqlParameter[] param = new SqlParameter[6];
                //para,[0]
                param[0] = new SqlParameter("@f_name", System.Data.SqlDbType.VarChar, 50);
                param[1] = new SqlParameter("@l_name", System.Data.SqlDbType.VarChar, 50);
                param[2] = new SqlParameter("@email", System.Data.SqlDbType.VarChar, 30);
                param[3] = new SqlParameter("@comment", System.Data.SqlDbType.VarChar, 600);
                param[0].Value = hfname;
                param[1].Value = hlname;
                param[2].Value = hemail;
                param[3].Value = hcomment;
              
                cmd.Parameters.AddRange(param);//add the parameters
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
                //SqlDataReader reader = cmd.ExecuteReader();
               myConn.Close();
            }
