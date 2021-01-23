        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = ProcessText(textBox1.Text, "%", "#");
        }
        string ProcessText(string s, string delim, string replaceWith)
        {
           return Regex.Replace(s, @""+ delim + "+", replaceWith);
        }
