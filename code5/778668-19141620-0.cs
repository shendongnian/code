    public void ProcessRequest(HttpContext context)
    {
        byte[] imageBytes;
        // Get the id of the image we want to show
        string imageId = context.Request.QueryString["ImageId"];
        // Get the image bytes out of the database
        using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
        {
            // Pass in the image id we got from the querystring
            SqlCommand cmd = new SqlCommand("SELECT image FROM PoliceMedal WHERE ImageId=" + imageId, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            reader.GetBytes(0, 0, imageBytes, 0, int.MaxValue);
        }
        context.Response.Buffer = true;
        context.Response.Charset = "";
        context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        context.Response.ContentType = "image/jpg";
        context.Response.BinaryWrite(imageBytes);
        context.Response.End();
    }
