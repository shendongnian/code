     void listPicker_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            
            if (this.listPicker.SelectedItems != null && this.listPicker.SelectionMode == SelectionMode.Multiple)
            {
                for (int i = 0; i < this.listPicker.SelectedItems.Count; i++)
                {
                    string str = ((Items)(this.listPicker.SelectedItems[i])).Name;
                    if (i == 0)
                    {
                       MessageBox.Show("Selected Item(s) is " + str);
                    }
                    else
                    {
                        //Some Code
                    }
                }
            }
            else if (this.listPicker.SelectionMode == SelectionMode.Single)
            {
                MessageBox.Show("Selected Item is " + ((Items)this.listPicker.SelectedItem).Name);
            }
        }
