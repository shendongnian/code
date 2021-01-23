            SqlConnection conn = new SqlConnection("Data Source="?";Initial Catalog="?";Integrated Security=True");
			
            SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE ID = @ID", conn);
			cmd.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = Convert.ToInt32(txtID.Text);
			SqlDataAdapter da = new SqlDataAdapter();
			da.SelectCommand = cmd;
			
			DataTable dt = new DataTable();
            
                conn.Open();
                da.Fill(dt);
                conn.Close();
            grvResults.DataSource = dt;
            grvResults.DataBind();
