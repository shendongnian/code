         protected void ddlStream_SelectedIndexChanged(object sender, EventArgs e)
           {          
            SqlConnection Con = new SqlConnection("connectionString");
            string query = "select [column name] from [table name] where [column name] ="+ddlStream.SelectedItem.Value;
            SqlCommand com = new SqlCommand(query, Con);
            chkStream.DataValueField = "Columnname";
            chkStream.DataTextField = "Columnname";
            conn.Open();
            DataReader reader1 = comm.ExecuteReader();
            chkStream.DataSource = reader1;
            chkStream.DataBind();   
          }
