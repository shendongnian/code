        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LeftList.SelectedIndex > -1)
            {
                int SelectedIndex = LeftList.SelectedIndex;
                string SelectedItem = LeftList.SelectedValue.ToString();
                //Add the selected item to the right side list
                RightList.Items.Add(SelectedItem);
                rightSideList.Add(SelectedItem);
                //Delete the item from the left side list
                //ListLps.Items.RemoveAt(SelectedIndex);
                if (leftSideList != null)
                {
                    //Remove the item from the collection list 
                    leftSideList.RemoveAt(SelectedIndex);
                    LeftList.Items.RemoveAt(SelectedIndex);
                }
            }
            
        }
