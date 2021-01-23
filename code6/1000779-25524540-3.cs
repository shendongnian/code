    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        LoadDataViewModel model = new LoadDataViewModel { IsLoadingData = true };
        content.Content = new LoadDataView { Model = model };
        await Task.Delay(3000);
        model.IsLoadingData = false;
    }
