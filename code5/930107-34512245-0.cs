    private async void button_Click(object sender, RoutedEventArgs)
    { 
        var nameTask = GetNameAsync();
        var cityTask= GetCityAsync();
        var rankTask= GetRankAsync();
        System.Threading.Tasks.Task.WaitAll(nameTask, cityTask, rankTask);
    
        nameTextBox.Text = nameTask.Result;
        cityTextBox.Text = cityTask.Result;
        rankTextBox.Text = rankTask.Result;
    }
