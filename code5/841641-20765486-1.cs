        ListItem newItem = null;
        foreach (ListItem item in ListBox1.Items)
        {
            if (item.Selected)
            {
                foreach (ListItem innerItem in ListBox2.Items)
                {
                    if (innerItem.Selected)
                    {
                        newItem = new ListItem();
                        newItem.Text = item.Text + innerItem.Text;
                        ListBoxResult.Items.Add(newItem);
                    }
                }
            }
        }
