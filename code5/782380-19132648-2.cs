    public void ProcessRequest(HttpContext context)
     {
        Int32 my_Id;
        if (context.Request.QueryString["getID"] != null)
        {
           my_Id = Convert.ToInt32(context.Request.QueryString["getID"]);
           context.Response.ContentType = "image/jpeg";
           Stream strm = ShowEmpImage(my_Id);
           byte[] buffer = new byte[4096];
           int byteSeq = strm.Read(buffer, 0, 4096);
           while (byteSeq > 0)
            {
               context.Response.OutputStream.Write(buffer, 0, byteSeq);
               byteSeq = strm.Read(buffer, 0, 4096);
            }
          }
    }
    
    public Stream ShowEmpImage(int my_Id)
    {
       string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
       SqlConnection connection = new SqlConnection(conn);
       string sql = "select blueBallImage from CorrespondingBall WHERE characterID = @ID";
       SqlCommand cmd = new SqlCommand(sql, connection);
       cmd.CommandType = CommandType.Text;
       cmd.Parameters.AddWithValue("@ID", my_Id);
       connection.Open();
       object img = cmd.ExecuteScalar();
       return new MemoryStream((byte[])img);
     }
