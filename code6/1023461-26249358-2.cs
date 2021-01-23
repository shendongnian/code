    using (StreamReader reader = File.OpenText(resource_path)) // path to file
    {
        while (reader.Peek() >= 0)
        {
            string[] parts = reader.ReadLine().Split('"');
            if (comboBox1.Text == result[0])
            {
                richTextBox2.Text = result[2];
            }
        }
    }
