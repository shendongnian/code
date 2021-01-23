    private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        for (int i = 4; i >= 0; i--)
        {
            if (l[i] == true)
            {
                checkedListBox1.Items.Remove(i);
            }
        }
    }
