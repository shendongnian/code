    private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
       if(listBox1.SelectedItem != null)
          Process.Start(listBox1.SelectedItem.ToString());
    }
