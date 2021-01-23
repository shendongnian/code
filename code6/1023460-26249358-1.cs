    using (StringReader reader = new StringReader(resource_data))
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
