    mainCycle(list);
    
    previousButton = (Control)list.Items.GetItemAt(list.Items.Count - 1);
            if (itemCounts >= 4)
            {
                MessageBox.Show("" + previousButton.Name);
                previousButton.Visibility = Visibility.Collapsed;
            }
