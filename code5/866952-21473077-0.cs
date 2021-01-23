     byte[] buffer;
    //this is the array of bytes which will hold the data (file)
    SqlConnection connection;
    protected void ButtonUpload_Click(object sender, EventArgs e)
    {
        //check the file
        if (FileUpload1.HasFile && FileUpload1.PostedFile != null 
            && FileUpload1.PostedFile.FileName != "")
        {
            HttpPostedFile file = FileUpload1.PostedFile;
            //retrieve the HttpPostedFile object
            buffer = new byte[file.ContentLength];
            int bytesReaded = file.InputStream.Read(buffer, 0, 
                              FileUpload1.PostedFile.ContentLength);
            if (bytesReaded > 0)
            {
                try
                {
                    string connectionString = 
                      ConfigurationManager.ConnectionStrings[
                      "uploadConnectionString"].ConnectionString;
                    connection = new SqlConnection(connectionString);
                    SqlCommand cmd = new SqlCommand
                    ("INSERT INTO Videos (Video, Video_Name, Video_Size)" + 
                     " VALUES (@video, @videoName, @videoSize)", connection);
                    cmd.Parameters.Add("@video", 
                        SqlDbType.VarBinary, buffer.Length).Value = buffer;
                    cmd.Parameters.Add("@videoName", 
                        SqlDbType.NVarChar).Value = FileUpload1.FileName;
                    cmd.Parameters.Add("@videoSize", 
                        SqlDbType.BigInt).Value = file.ContentLength;
                    using (connection)
                    {
                        connection.Open();
                        int i = cmd.ExecuteNonQuery();
                        Label1.Text = "uploaded, " + i.ToString() + " rows affected";
                    }
                }
                catch (Exception ex)
                {
                    Label1.Text = ex.Message.ToString();
                }
            }
        }
        else
        {
            Label1.Text = "Choose a valid video file";
        }
    }
