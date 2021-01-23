    // in Button_Click
    var train = await GetTrainSheldure();
    
    // method
    public async Task<Train> GetTrainSheldure()
    {
      var date = DatePicker.Date.Year // ... etc.
      var suggestion = Suggestions.Text
      var suggestion1 = Suggestions1.Text
      return Task.Run(()=>TrainGrabber.GetTrainSheldure(suggestion, suggestion1, date));
    }
