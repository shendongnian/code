    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BancoEstadoConnectionString"].ToString()))
        {
            SqlCommand comand = new SqlCommand(query, conn);
            DataSet ds = new DataSet();
            conn.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(ds, "Authors");
            Select1.DataSource = ds;
            Select1.DataTextField = "au_fname";
            Select1.DataValueField = "au_fname";
            Select1.DataBind();
        }
