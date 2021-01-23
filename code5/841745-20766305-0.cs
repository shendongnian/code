    private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
    {
        List<string> myValue;
        if(phoneAppService.State.TryGetValue("_List", out myValue))
        {
            list.ItemsSource  = myValue;
        }
    }
