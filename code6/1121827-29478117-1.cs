    private void button1_Click(object sender, EventArgs e)
        {
            List<string[]> myArrayList = new List<string[]>();
            StreamReader read = new StreamReader(@"C:\test\Accounts.txt");
            string line;
            while ((line = read.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                //Console.WriteLine(parts[0]);
                myArrayList.Add(parts);
            }
            foreach (var account in myArrayList)
            {
                richTextBox1.Text = richTextBox1.Text + account[0].ToString() + Environment.NewLine;
            }
        }
