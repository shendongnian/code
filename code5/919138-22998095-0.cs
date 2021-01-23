    using (SqlConnection db = new SqlConnection())
    {
        db.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AboutYouEntities"].ConnectionString;
        db.Open();
        using (SqlCommand insertUser = new SqlCommand())
        {
            insertUser.Connection = db;
            insertUser.CommandText = "INSERT into [USER] (Email, Name, Gender, BirthDate, LinuxDistro) VALUES (@Email, @Name, @Gender,@BirthDate, @LinuxDistro);";
            insertUser.Parameters.AddWithValue("@Email", userInfo.Email);
            insertUser.Parameters.AddWithValue("@Name", userInfo.Name);
            insertUser.Parameters.AddWithValue("@Gender", userInfo.Gender);
            insertUser.Parameters.AddWithValue("@BirthDate", userInfo.BirthDate);
            insertUser.Parameters.AddWithValue("@LinuxDistro", userInfo.LinuxDistro);
            insertUser.ExecuteNonQuery();
        }
        using (SqlCommand insertContact = new SqlCommand())
        {
            insertContact.Connection = db;
            insertContact.CommandText = "INSERT into CONTACT (Phone, Zip, Comments) VALUES (@Phone, @Zip, @Comments);";
            insertContact.Parameters.AddWithValue("@Phone", userContact.Phone);
            insertContact.Parameters.AddWithValue("@Zip", userContact.Zip);
            insertContact.Parameters.AddWithValue("@Comments", userContact.Comments);
            insertContact.ExecuteNonQuery();
        }
    }
