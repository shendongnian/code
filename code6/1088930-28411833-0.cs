    public async Task LoadMyData(IPeopleService peopleService)
    {
       try
       {
          ... // Hide people display
          ... // Show loading indicator
          People = await peopleService.GetPeopleAsync();
          ... // Show people display
       }
       catch(Exception e)
       {
          ... // Show error indicator
       }
       finally
       {
          ... // Hide loading indicator
       }
    }
