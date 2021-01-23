    Using System.Linq 
     private void ContactList_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            VisualTreeHelper.FindElementsInHostCoordinates(e.GetPosition(null), (sender as ListBox)).OfType<ListBoxItem>().First().IsSelected = true;
        }    
