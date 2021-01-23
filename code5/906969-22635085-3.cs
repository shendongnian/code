    List<string> list = new List<string>();
    ...
    ...
    while(reader.Read())
    {
       list.Add(reader[0].ToString());
    }
    TextBox1.Text = String.Join(" ", list.ToArray());
