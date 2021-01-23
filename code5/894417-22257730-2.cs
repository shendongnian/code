    private void Close_Click(object sender, RoutedEventArgs e)
    {
        TestModel testModel = this.DataContext as TestModel;
        testModel.IsClose = true;
    }
