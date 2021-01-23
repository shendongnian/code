    private void DisplayCustomerName()
    {
        foreach (CSVEntry entry in CSVList)
        {
              ListItem item = new ListItem(entry.customerName);
             if (!customerNameListBox.Items.Contains(item) )
             {
                  customerNameListBox.Items.Add(item);
             }
        }
    }
