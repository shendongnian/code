    private void button1_Click(object sender, EventArgs e)
    {
        string[] oldString = TextBox1.Text.Split(
            new string[]{","},
            StringSplitOptions.RemoveEmptyEntries);
        foreach (string item in oldString)
        {
            ListBox1.Items.Add(item);
        }
    }
