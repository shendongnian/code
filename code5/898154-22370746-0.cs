    private void clBox_MouseUp(object sender, MouseEventArgs e)
    {
        if (clBox.CheckedItems.Contains(clBox.SelectedItem))
        {
            MessageBox.Show("Test");
        }
    }
