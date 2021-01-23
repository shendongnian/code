    protected void DownloadFile(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        byte[] bytes;
        string fileName, contentType;
    
        // Test code  to download 123.sql file from C:\
        bytes = System.IO.File.ReadAllBytes("C:\\123.sql");
        contentType = ".sql";
        fileName = "123.sql";
        //string constr = ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString;
        //using (SqlConnection con = new SqlConnection(constr))
        //{
        //    using (SqlCommand cmd = new SqlCommand())
        //    {
        //        cmd.CommandText = "select FileName,Extentions, FileContent from Documents where ID=" + id;
        //        cmd.Parameters.AddWithValue("@Id", id);
        //        cmd.Connection = con;
        //        con.Open();
        //        using (SqlDataReader sdr = cmd.ExecuteReader())
        //        {
        //            sdr.Read();
        //            bytes = (byte[])sdr["FileContent"];
        //            contentType = sdr["Extentions"].ToString();
        //            fileName = sdr["FileName"].ToString();
        //        }
        //        con.Close();
        //    }
        //}
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = contentType;
        Response.AddHeader("Content-type", contentType);
        Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();
    }
