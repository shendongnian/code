    bool UploadSuccess = false;
    cn.Open();
    SqlCommand com = new SqlCommand("UPDATE tblStudent set EmailAddress=@EmailAddress, Password=@Password", cn);
    {
        com.Parameters.AddWithValue("@EmailAddress", student.EmailAddress);
        com.Parameters.AddWithValue("@Password", student.Password);
        try
        {
            com.ExecuteNonQuery();
        }
        catch(Exception e)
        {
            throw e;
        }
        cn.Close();
        if (i != 0)
            UploadSuccess = true;
        return UploadSuccess;
    }
