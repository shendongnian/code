        private void SaveBtn_Click(object sender, EventArgs e)
        {
            using(Stream stream = File.Create(NameTb.Text + ".txt"))
            {
                TextWriter tw = new StreamWriter(stream); /* this is where the problem was */
                tw.WriteLine("The very first line!");
                tw.Close();
            }
        }
