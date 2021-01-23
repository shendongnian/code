    private void button2_Click(object sender, EventArgs e)
    {
        string source = textBox1.Text
        string destination = textBox2.Text;
        if (mappings.ContainsKey(source))
        {
            foreach (var f in Directory.GetFiles(source))
            {
                File.Copy(f, Path.Combine(destination, Path.GetFileName(f)));
            }
        }
        else
        {
            // No key was found, how you handle it will be dictated by the needs of the application and/or users.
        }
    }
