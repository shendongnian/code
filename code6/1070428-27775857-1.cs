    private async void button_Tapped(object sender, TappedRoutedEventArgs e)
    {
        await MyTableRepository.UpdateAsync(scheduleRecord);
    
        this.DefaultViewModel["MyViewModel"] = await ViewModelClass.GetMyTableDataAsync();
    }
