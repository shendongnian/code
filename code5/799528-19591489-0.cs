    private void DetailButton_Click_1(object sender, RoutedEventArgs e)
    {
        var clickedUIElement =  sender as Button;
        if (null == clickedUIElement) { Return; }
        Display selectedItemData = clickedUIElement.DataContext as Display;
        if(null != selectedItemData)
        {
            NavigationService.Navigate("/page3.xaml", selectedItemData);
        }
    }
