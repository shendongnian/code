      public class Service1 : IService1
      {
        public string SaveFile(byte[] buffer)
        {
            using (var connection = 
                   new SqlConnection(ConfigurationManager.ConnectionStrings["myCnnStr"].ToString()))
            {
                var cmd = new SqlCommand(
                        "INSERT INTO Images (ImageData) VALUES(@buffer)",
                        connection);
                cmd.Parameters.Add(new SqlParameter("buffer", buffer));              
                connection.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    // log exception
                    return "fail";
                }
           }
            return "ok";
        }
     }
