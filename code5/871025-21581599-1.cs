    Com.CommandText = "SELECT * FROM search";
    OleDbDataReader reader = Com.ExecuteReader();
    var words = new List<string>();
    while (reader.Read())
    {
        if (string.Compare(label1.Text, reader.GetString(0)) == 0)
        {
            for (int i = 1 ; i < 5 ; i++)
            {
                words.Add(reader.GetString(i));
            }
        }
    }
    reader.Close();
    conn.Close();
    
    listbox1.Items.AddRange(words.ToArray());
    words.Shuffle();
    listbox4.Items.AddRange(words.ToArray());
