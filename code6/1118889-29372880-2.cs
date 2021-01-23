    while (reader.Read())
    {
        TextBox dynamicTextbox = new TextBox();
        Panel1.Controls.Add(dynamicTextbox );
        dynamicTextbox.Text = reader[4].ToString();
    }
