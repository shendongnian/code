    private void TimerElapsed(...)
    {
        int i = 0;
        i = listBox1.SelectedIndex;
        i++;
        if (i > listBox1.Items.Count - 1)
        {
           MessageBox.Show("End of list reached!");
           if (LoopAfterEnd)
              i = 0;
           else
              Timer1.Stop();
        }
        listBox1.SelectedIndex = i;
        MessageBox.Show("Item: " + listBox1.SelectedItem.ToString());
    }
