    public byte[] GetImageData(int ID)
    {
        string cmdText = "select FileImage from TestServ.dbo.Tickets " + 
                         "WHERE (FileType = 'PDF' AND ID = @id)";
        SqlCommand command = new SqlCommand(cmdText, connection);
        command.Parameters.AddWithValue("@id", ID);
 
        ....
    }
