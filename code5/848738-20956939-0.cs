    if (findTextBox.Text != "")
    {
        List<ListViewItem> items = new List<ListViewItems>();
        foreach ListViewItem lvi in listItemsList.Items
        {
             if (lvi.Text == findTextBox.Text)
                items.Add(lvi);
        }
    
        amountFound.Text = "Found " + Convert.ToString(lviFoundList.Count());
    
        if(lviFoundList.Count() != 0)
        {
            int firstItemIndex = lviFoundList[0].Index;
            listItemsList.Items[firstItemIndex].Selected = true;
        }
    
    
    
    }
    else
    {
        amountFound.Text = "Found 0";
    }
 
