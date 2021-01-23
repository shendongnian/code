    private void next_Click(object sender, EventArgs e)
    {
        if (index < customers.Count - 1)
        {
            index += 1;
            textBox1.Text = customers[index].Name;
            ...
        }
    }
    private void previous_Click(object sender, EventArgs e)
    {
        if (index > 0)
        {
            index -= 1;
            textBox1.Text = customers[index].Name;
            ...
        }
    }
