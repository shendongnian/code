    SqlConnection con = new SqlConnection("Data Source=ServerName;Initial Catalog=CatalogName;Integrated Security=True");            
            string str = "SELECT [BBID], [Name], [ContactNum], [Email], [Gender], [BloodGroup], [Category], [Address] FROM [Bloodbank] WHERE ([Category] = @Category)";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlParameter param = new SqlParameter("Category", SqlDbType.NVarChar, 10);
            cmd.Parameters.Add(param);
            param.Value = "Donor";
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
      
