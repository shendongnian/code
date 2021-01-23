    foreach (ListViewItem item in listView_supplierNames.Items)
                {
                    if (item.Checked)
                    {
    
                    }
                    else
                    {
                        //Remove unchecked Items
                         listView1.Items.Remove(item);
                    }
                }
