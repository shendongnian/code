    private async void GetPieName()
    {
        await GetPieNameAsync();
    }
    private async Task GetPieNameAsync()
    {
        string asyncPieName = string.Empty;
        try
        {
            var task = _pieMaker.GetDeliciousPieAsync();
            asyncPieName = await task;
        }
        catch (RottenFruitException e)
        {
            Debug.Write(e.Message);
        }  
        if (!string.IsNullOrEmpty(asyncPieName))
        {
            _pieName = asyncPieName;
            NotifyPropertyChanged(PieName);
        }
    }
