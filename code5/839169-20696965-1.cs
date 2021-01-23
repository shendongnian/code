    private void AddItem_Click(object sender, EventArgs e)
    {
        listBox1.Items.Add(textBox1.Text);
    }
    private void RemoveItem_Click(object sender, EventArgs e)
    {
        listBox1.Items.Remove(listBox1.SelectedItem);
    }
