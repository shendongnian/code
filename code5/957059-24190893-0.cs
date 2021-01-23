    private async void DoAsyncWork()
    { 
       var data = await GetProjectAsync();
    }
    async Task<string> GetProjectAsynce()
    {
        // code to get stuff done
        // await key word may be needed depending on
        // what you are doinf
        return JsonConvert.SerializeObject(myRepository.All<Projects>());
        // convert to string first of course 
    }
