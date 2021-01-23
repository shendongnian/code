        private void ListBox_KeyUp(object sender, KeyEventArgs e)
        {
            int selectIndex = listBox.SelectedIndex;
            int listItemCount = listBox.Items.Count;
            if (e.Key == Key.Enter)
            {
                if (selectIndex == listItemCount - 1)
                {
                    ListBoxItem newItem = new ListBoxItem();
                    newItem.Content = "Your Content";
                    listBox.Items.Add(newItem);
                    listBox.SelectedItem = newItem;
                }
                else
                {
                    listBox.SelectedIndex = selectIndex + 1;
                }
            }
        }
