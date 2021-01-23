    private void button1_Click(object sender, EventArgs e)
        {
            string selected = listBox1.GetItemText(listBox1.SelectedValue);
            MessageBox.Show(selected);
        }
