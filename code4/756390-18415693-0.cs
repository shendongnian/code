    checkedListBox1.ItemCheck +=checkedListBox1_ItemCheck;
    private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        for (int i = 0; i < checkedListBox1.Items.Count; i++)
        {
            if (i != e.Index)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }
    }
