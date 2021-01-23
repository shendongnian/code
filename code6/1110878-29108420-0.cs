        string addQuotes(string val)
        {
            string[] ss = val.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            string res = "";
            foreach (string s in ss) res += (res == "" ? "" : ", ") + "'" + s + "'";
            return res;
        }
        void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = addQuotes(textBox1.Text);
        }
