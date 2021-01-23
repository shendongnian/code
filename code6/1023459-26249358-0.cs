    string[] lines = resource_data.Split(new string[1] { Environment.NewLine }, StringSplitOptions.None);
    foreach (var line in lines)
    {
        string[] parts = line.Split('"');
        if (comboBox1.Text == result[0])
        {
            richTextBox2.Text = result[2];
        }
    }
