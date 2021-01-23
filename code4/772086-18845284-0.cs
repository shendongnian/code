    private async Task<string> getAllData()
    {
        string Result = "";
        var http = new HttpClient();
        var response = await http.GetAsync("http://webservice.com/wfwe"); // I am considering this URL gives me JSON
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            Result = await response.Content.ReadAsStringAsync(); // You will get JSON here
        }
        else
        {
            Result = response.StatusCode.ToString(); // Error while accesing the web service.
        }
    
        return Result;
    }
    
    private async Task GetApplications(string result)
    {
        var ApplicationsList = JsonConvert.DeserializeObject<List<Applications>>(result);
        foreach (Applications A in ApplicationsList)
        {
            foreach (ApplicationRelation SCA in A.ApplicationRelations)
            {
                if (SCA.ApplicationSubcategory != null)
                {
                    #region Fill Customer Research Stack
                    if (SCA.ApplicationSubcategory.subcategoryName == "Customer Research")
                    {
                        if (TestStack.Children.Count == 0)
                        {
                            // This will update your UI using UI thread
                            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
                            {
                                ApplicationTile AT = FillDataForApplicationTile(SCA);
                                AT.Margin = new Thickness(5, 0, 5, 0);
                                TestStack.Children.Add(AT);
                            });
                        }
                    }
                    #endregion
                }
            }
        }
    }
