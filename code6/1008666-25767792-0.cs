    public async void UpdateMyThing() {
         LoadingIndicator.IsEnabled = true; //or something like that
         var query = ...
         await Task.Run(() => Functions.UpdateInsert(query));
         LoadingIndicator.IsEnabled = false; //we are done
    }
