     private void DetailButton_Click_1(object sender, RoutedEventArgs e)
        {
            If ((sender as ListBox).SelectedValue != null){
                 Display selectedItemData = (sender as ListBox).SelectedValue as Display;
                 NavigationService.Navigate("/page3.xaml", selectedItemData);
            }
        }
