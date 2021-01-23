    bool genderval;
    using (SqlConnection conn = new SqlConnection("youeConnStr"))
    {
        conn.Open();
        using (SqlCommand cmd = new SqlCommand("SELECT Gender FROM Std_info WHERE Id = @id", conn))
        {
            int id = Convert.ToInt32(TextBox1.Text);
            cmd.Parameters.Add(new SqlParameter("@id", id));
            genderval = (bool)cmd.ExecuteScalar();
        }
    }
