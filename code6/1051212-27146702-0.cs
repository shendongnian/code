    void itemListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.UsingLogicalPageNavigation())
            {
                this.navigationHelper.GoBackCommand.RaiseCanExecuteChanged();
            }
            var mySelectedItem = e.AddedItems[0];
            MyObject myObject = (MyObject)mySelectedItem;
            // Now you can access your property as follows: myObject.MyProperty;
        }
