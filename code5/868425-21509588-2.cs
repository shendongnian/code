    using(SqlConnection connect = new SqlConnection("Data Source=JMSANTOS-PC;Initial Catalog='Purchasing Department';Integrated Security=True"))
    {
       using(SqlCommand statement = new SqlCommand())
       {
          statement.Connection = connect;
          statement.CommandText = "INSERT INTO dbo.Register
                                   VALUES (@user, @pass, @last, @first, @address, @contact)";
          statement.Parameters.AddWithValue("@user", Username.Text);
          statement.Parameters.AddWithValue("@pass", Password.Text);
          statement.Parameters.AddWithValue("@last", LastName.Text);
          statement.Parameters.AddWithValue("@first", FirstName.Text);
          statement.Parameters.AddWithValue("@address", Address.Text);
          statement.Parameters.AddWithValue("@contact", Contactno.Text);
          connect.Open();
          statement.ExecuteNonQuery();
       }
    }
