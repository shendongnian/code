    protected void getUnits()
     {
       try
       {
        System.Data.SqlClient.SqlDataReader dr = null;
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["AbleCommerce"].ToString()))
        {
            SqlCommand cmd = new SqlCommand("SELECT [name] FROM [baird_UnitOfMeasure]", cn);
            cmd.CommandType = CommandType.Text;
            cn.Open();
            using (IDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                   if(!String.IsNullOrEmpty(unitValues.Text)){
                      unitValues.Text += ", ";
                   }
                   unitValues.Text += reader["name"].ToString();
                }
             }
            cn.Close();
        }
       }
       catch (Exception ex)
       {
          \\catch error
       }
    }
