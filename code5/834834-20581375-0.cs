    var selectSql = "SELECT Shuma FROM Useri WHERE Pin = @Pin";
    var updateSql = "UPDATE Useri SET Shuma = @Shuma WHERE Pin = @Pin";
    
    using (SqlConnection c = new SqlConnection(cString))
    {
        c.Open();
        
        double balanciFillestar;
        using (SqlCommand cmd = new SqlCommand(selectSql, c))
        {
            cmd.Parameters.AddWithValue("@Pin", textBox1_Pin.Text);
    
            balanciFillestar = Convert.ToDouble(cmd.ExecuteScalar());
        }
        
        double balanciRi = balanciFillestar + double.Parse(textBox_shuma.Text);
        using (SqlCommand cmd = new SqlCommand(updateSql, c))
        {
            cmd.Parameters.AddWithValue("@Shuma", balanciRi);
            cmd.Parameters.AddWithValue("@Pin", textBox1_Pin.Text);
            
            cmd.ExecuteNonQuery();
        }
    }
