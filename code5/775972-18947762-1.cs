    private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
       if(listBox1.SelectedItem != null)
          Process.Start(((FileInfo)listBox1.SelectedItem).FullName);
    }
