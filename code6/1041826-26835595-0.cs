    using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB  rest of my connstring.... "))
    {
        using (SqlCommand update = new SqlCommand("Update tblImages SET Name=@name, Descript=@descript WHERE Id=@id", connection))
        {
            connection.Open();
            update.Parameters.Add("@name", TextBox3.Text);
            update.Parameters.Add("@descript", TextBox4.Text);
            update.Parameters.Add("@id", id);
            update.ExecuteNonQuery();
        }
    }
