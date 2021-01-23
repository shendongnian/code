        private void ListBox_SelectionChanged( object sender, SelectionChangedEventArgs e)
        {
            String lstbox = (sender as TextBox).Name;
            switch(lstbox)
            {
                    
                case "ListBoxEffects":
                        if(ListBoxEffects.SelectedItem == ListBoxEffects1.SelectedItem)
                        {
                            MessageBox.Show("Item already selected");
                        }
                        else
                         //ur code
                    break;
               case "ListBoxEffects1":
                    if(ListBoxEffects.SelectedItem == ListBoxEffects1.SelectedItem)
                    {
                        MessageBox.Show("Item already selected");
                    }
                    else
                         //ur code
                    break;
            }
        }
