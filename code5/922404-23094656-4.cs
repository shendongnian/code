    private void TimerElapsed(...)
    {
        int i = 0;
        i = listBox1.SelectedIndex;
        i = i + 1;
        if (i > listBox1.Items.Count - 1)
        i = 0;
        listBox1.SelectedIndex = i;
        MessageBox.Show("Item: " + listBox1.SelectedItem.ToString());
    }
