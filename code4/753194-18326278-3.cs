            public string Remove(string statement, string toRemove)
        {
            int start = statement.IndexOf(toRemove);
            int end = toRemove.Length;
            statement = statement.Remove(start, end);
            return statement;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (string line in richTextBox1.Text.Split('\n'))
            {
                if (line.Split(' ')[0] == "ALTER" && line.Split(' ')[1] == "TABLE" && line.Contains("USER1"))
                {
                    int start = richTextBox1.Text.IndexOf(line);
                    int end = line.Length - 1;
                    richTextBox1.Text = richTextBox1.Text.Remove(start, end).Insert(start, Remove(line, "\"USER1\"."));
                }
            }
        }
