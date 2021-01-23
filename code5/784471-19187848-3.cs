    public string getSalt()
    {
        string sql = "select DISTINCT Salt from Logins where Name = @username"; 
        using (var connection = new SqlConnection(@"server=.\SQLEXPRESS; database=loginsTest;Trusted_Connection=yes")) 
        using (var command = new SqlCommand(sql, connection))
        {
            //guessing at the column length here. Use actual column size instead of 20
            command.Parameters.Add("@username", SqlDbType.NVarChar, 20).Value = userNameBox.Text;
            connection.Open();
            return (command.ExecuteScalar() as string) ?? "Error";
        }
    }
