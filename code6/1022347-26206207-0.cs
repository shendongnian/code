        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("9");
            listBox1.Items.Add("15");
            listBox1.Items.Add("27");
            int x = int.Parse(listBox1.Items[0].ToString());
            MessageBox.Show(x.ToString());
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = int.Parse(listBox1.SelectedItem.ToString());
            MessageBox.Show(x.ToString());
        }
