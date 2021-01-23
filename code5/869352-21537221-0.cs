    SqlConnection conn = new SqlConnection("Server=portable;Database=data;Integrated Security=true;");
    conn.Open();
    SqlCommand cmd = new SqlCommand("SELECT bnry FROM RawData", conn);
    SqlDataReader reader = cmd.ExecuteReader();
    
    while(reader.Read())
    {
        var valueAsArray = (byte[])reader["bnry"];
        //need to find encoding what works for you
        var valueAsStringDefault = System.Text.Encoding.Default.GetString(valueAsArray);
        var valueAsStringUTF8 = System.Text.Encoding.UTF8.GetString(valueAsArray);
        var valueAsStringUTF7 = System.Text.Encoding.UTF7.GetString(valueAsArray);
        Console.WriteLine(valueAsStringDefault);
        Console.WriteLine(valueAsStringUTF8);
        Console.WriteLine(valueAsStringUTF7);
    }
    
    reader.Close();
    conn.Close();
