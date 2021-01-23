    protected void Button1_Click(object sender, EventArgs e)
    {
        int index = ListBox1.SelectedIndex;
        if (index != -1)
        {
            ListBox1.Items.RemoveAt(index);
        }
    }
