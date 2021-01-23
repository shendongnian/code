    private void button1_Click(object sender, EventArgs e)
    {
        string[] oldString = TextBox1.Text.Split(
            new string[]{","},
            StringSplitOptions.RemoveEmptyEntries);
        ListBox1.Items.AddRange(oldString);
    }
