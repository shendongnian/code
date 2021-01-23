    SqlConnection conn = new SqlConnection("Server=portable;Database=data;Integrated Security=true;");
    conn.Open();
    SqlCommand cmd = new SqlCommand("SELECT bnry FROM RawData", conn);
    SqlDataReader reader = cmd.ExecuteReader();
    
    while(reader.Read())
    {
        var valueAsArray = (byte[])reader["bnry"];
        //as there are different encodings possible, you need to find encoding what works for you
        var valueAsStringDefault = System.Text.Encoding.Default.GetString(valueAsArray);
        Console.WriteLine(valueAsStringDefault);
        //...or...
        var valueAsStringUTF8 = System.Text.Encoding.UTF8.GetString(valueAsArray);
        Console.WriteLine(valueAsStringUTF8);
        //...or...
        var valueAsStringUTF7 = System.Text.Encoding.UTF7.GetString(valueAsArray);
        Console.WriteLine(valueAsStringUTF7);
        //...or any other encoding. Most of them you can find in System.Text.Encoding namespace...
    }
    
    reader.Close();
    conn.Close();
