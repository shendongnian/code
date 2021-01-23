    private void button1_Click(object sender, EventArgs e)
        {
            OnButtonClick();
        }
        private void OnButtonClick()
        {
            listBox2.Items.Add(listBox1.SelectedItem);
            listBox1.Items.Remove(listBox1.SelectedItem);
            button1.Enabled = listBox1.Items.Count > 0;
        }
