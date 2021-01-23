    private void myLV_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (myLV.SelectedItems.Count > 0)
        {
            foreach (ListViewItem item in myLV.SelectedItems)
            {
                if (item.ForeColor == Color.Gray)
                {
                    item.Selected = false;
                }
                else
                {
                    ListViewItem tempItem = item;
                    grayOut2(ref tempItem);
                }
            }
        }
    }
