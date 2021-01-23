    public string getSalt()
    {
        string sql = "select DISTINCT Salt from Logins where Name = @username"; 
        string result;
        using (var connection = new SqlConnection(@"server=.\SQLEXPRESS; database=loginsTest;Trusted_Connection=yes")) 
        using (var command = new SqlCommand(selection, connection))
        {
            command.Parameters.Add("@username", SqlDbType.NVarChar, 20).Value = userNameBox.Text;
            connection.Open();
            return (command.ExecuteScalar() as string) ?? "Error";
        }
    }
