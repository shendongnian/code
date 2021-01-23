    using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB  rest of my connstring.... "))
    {
        using (SqlCommand update = new SqlCommand("Update tblImages SET Name = @name, Descript = @descript WHERE Id = @id", connection))
        {
		    update.Parameters.Add(new SqlParameter("@name", TextBox3.Text));
		    update.Parameters.Add(new SqlParameter("@descript", TextBox4.Text));
		    update.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            update.ExecuteNonQuery();
        }
    }
