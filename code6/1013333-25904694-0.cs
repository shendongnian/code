        public void ProcessRequest (HttpContext context) 
            {
    string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        
                SqlConnection conn = new SqlConnection(connectionString);
        
                SqlCommand cmd = new SqlCommand();
        
                cmd.CommandText = "Select [Content] from Images where ID =@ID";
        
                cmd.CommandType = CommandType.Text;
        
                cmd.Connection = conn;
             
                SqlParameter ImageID = new SqlParameter("@ID", SqlDbType.BigInt);
                ImageID.Value = context.Request.QueryString["ID"];
                cmd.Parameters.Add(ImageID);
                conn.Open();
                SqlDataReader dReader = cmd.ExecuteReader();
                dReader.Read();
                context.Response.BinaryWrite((byte[])dReader["Content"]);
                dReader.Close();
                conn.Close();
            }
