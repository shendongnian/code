    int count = 0;
    private void button_Click(object sender, EventArgs e)
    {
    }
    private int TotalCount()
    {
        ++count;
        return count;
    }
    private void buttonCount_Click(object sender, EventArgs e)
    {
        int totalcount = TotalCount();
        MessageBox.Show("The number clicked is: " + totalcount);
    }
