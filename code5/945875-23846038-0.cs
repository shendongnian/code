    reader = cmd.ExecuteReader();
    
    try
    {
        if (reader.HasRows)
        {
            reader.Read();
            if (!reader.IsDBNull(0))
	            TextBox1.Text = reader.GetString(0);
         }
    }
    catch (Exception ex)
    {
        // Do something
    }
    finally
    {
        reader.Close();
    }
