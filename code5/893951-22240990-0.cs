    private async void RunTasks()
    {
        tasks[0] = HttpExtensions.GetMyData("http://www....");
        tasks[1] = HttpExtensions.GetMyData("http://www.....");
        tasks[2] = GeoLocate.OneShotGeoLocate();
        try
        {
            await Task.WhenAll(tasks);
        }
        catch (Exception ae)
        {
            App.ViewModel.ErrorMessage = ae.Message;
        }
    }
