    private void button_Click(object sender, RoutedEventArgs e) 
    {
        var myModel = (ViewModel.EntityViewModel)(yourStackPanelName.DataContext);
        myModel.ActiveEntity.Label = "test";
    }
