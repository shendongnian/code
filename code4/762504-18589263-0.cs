    public void InsertMember(Member member)
    {
        string INSERT = "INSERT INTO Members (Name, Surname, EntryDate) VALUES (@Name, @Surname, @EntryDate)";
        using (sqlConnection = new SqlConnection(sqlConnectionString_WORK))
        {
            sqlConnection.Open();
            using (SqlCommand sqlCommand = new SqlCommand(INSERT, sqlConnection))
            {
                sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = member.Name;
                sqlCommand.Parameters.Add("@Surname", SqlDbType.VarChar).Value = member.Surname;
                sqlCommand.Parameters.Add("@EntryDate", SqlDbType.Date).Value = member.EntryDate;
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
