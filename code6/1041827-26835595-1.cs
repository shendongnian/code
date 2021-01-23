    using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB  rest of my connstring.... "))
    {
        using (SqlCommand update = new SqlCommand("Update tblImages SET Name=@name, Descript=@descript WHERE Id=@id", connection))
        {
            connection.Open();
            update.Parameters.AddWithValue("@name", TextBox3.Text);
            update.Parameters.AddWithValue("@descript", TextBox4.Text);
            update.Parameters.AddWithValue("@id", id);
            update.ExecuteNonQuery();
        }
    }
