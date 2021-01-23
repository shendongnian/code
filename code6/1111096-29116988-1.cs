    if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
    {
        label3.Text = openFileDialog1.FileName;
        textBox1.Text = File.ReadAllText(label3.Text);
        FileStream fs = File.OpenRead(label3.Text);
        string[] lines = new StreamReader(fs).ReadToEnd().Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        fs.Close();
        List<string> list2 = new List<string>();
        for (int i = 0; i < lines.Length; i++)
        {
            char[] chars = lines[i].ToCharArray();
            for (int j = 0; j < chars.Length; j++)
            {
                if (!Char.IsWhiteSpace(chars[j]))
                    list2.Add(chars[j].ToString());
            }
        }
    }
