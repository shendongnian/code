     private void button1_Click(object sender, EventArgs e)
        {
            List<string> rt = new List<string>();
            foreach (string line in richTextBox1.Lines)
            {
                if (!string.IsNullOrEmpty(line.Trim()))
                {
                    rt.Add(line);
                }
                if (line.Trim().EndsWith(";"))
                {
                    rt.Add("\n");
                }
            }
            richTextBox1.Lines = rt.ToArray();
            richTextBox1.Refresh();
        }
