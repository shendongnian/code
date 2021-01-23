    // This is the DAL layer:
    public DataSet DownloadFile(int fileId)
    {
        //I don't know from where you are taking your command and connection, but I will assume that this is working correctly, I don't like this method ! Also close a connection only on catch block? Your are using only one connection ? If you tell me that this method is not working I will re write it too. 
    
    cmd.CommandText = "SELECT  [fileId],[fileName],[fileData],[postedBy] FROM  [dbo].[FilesLibrary] where fileId=@Id";
    cmd.Parameters.AddWithValue("@Id", fileId);
    cmd.Connection = cmd.Connection;
    
    try
    {
        cmd.Connection.Open();
    
        DataSet dst = new DataSet();
        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
        {
            adapter.Fill(dst, "FilesLibary");        
        }
        
        return dst;
    }
    catch (Exception ex)
    {
        cmd.Connection.Close();
        throw;
    }
    
    }
    // The BL is below:        
    public byte[] GetFileDownload(int fileId)
    {
        try
        {
            DataSet fileDst = new DownloadFile();// method from DA layer
            return (byte[])fileDst.Tables[0].Rows[0]["fileData"];
        }
        catch (Exception ex) { throw ex; }
    }
    protected void DownloadFile(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        byte[] bytes = fileInfo.GetFileDownload(id);
    //Now do your magic, if you want to have fileName in the business logic you should take GetFileDownload should return DataSet. After that take byte[] and fileName. I will write the fileName to be test for this case to not re write everything here !
    Response.Clear();
    Response.Buffer = true;
    Response.Charset = "";
    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    Response.ContentType = contentType;
    Response.AppendHeader("Content-Disposition", "attachment; filename=Test");
    Response.BinaryWrite(bytes);
    Response.Flush();
    Response.End();
    }
