    private void button1_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            StreamReader sr = new StreamReader(openFileDialog1.FileName);
            string s = sr.ReadToEnd();
            richTextBox1.Text = s;
        }
        string txt = richTextBox1.Text;
        var foundWords = Regex.Matches(txt, @"(?<=>)(\w+?)(?=<)");
        richTextBox1.Text = string.Join("\n", foundWords.Cast<Match>().Select(x=>x.Value).ToArray());
    }
