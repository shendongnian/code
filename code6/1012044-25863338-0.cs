        public class ImageHandler : IHttpHandler
        {
          public void ProcessRequest(HttpContext context)
          {
             int id = context.Request.QueryString.Get("ID");
             SqlDataReader rdr;
             byte[] fileContent = null;
             const string connect = @"Server=your_servername;Database=your_database;User 
             Id=user_id;password=user_password;";
             using (var conn = new SqlConnection(connect))
             {
                var qry = "SELECT FileContent, MimeType, FileName FROM FileStore WHERE ID = @ID";
                var cmd = new SqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@ID", id);
                conn.Open();
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                  rdr.Read();
                  context.Response.Clear();
                  context.Response.ContentType = rdr["MimeType"].ToString();
                  context.Response.BinaryWrite((byte[])rdr["FileContent"]);
                  context.Response.End();
                }
             }
          }
         
          public bool IsReusable
          {
            get
            {
              return true;
            }
          }
        }
