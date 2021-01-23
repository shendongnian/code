    [WebMethod]
    public bool EditAccount(Student student)
    {
    
        string cmdText = @"UPDATE tblStudent set [EmailAddress]=" + student.EmailAddress +
                          [Password]="+ student.Password +" where [StudentNumber]=" + student.StudentNumber;
        bool UploadSuccess = false;
        var con = new SqlConnection(constring));
        var SqlCommand com = new SqlCommand{
                CommandType = CommandType.Text,
                CommandText = cmdText ,
                Connection = con 
             };
        try
         { 
            con.Open();
            int i = com.ExecuteNonQuery();
            if (i != 0)
                UploadSuccess = true;
          }
          finally
          {
            con.close();
          }
            return UploadSuccess;
    }
