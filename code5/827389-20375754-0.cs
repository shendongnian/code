    try
    {
        var response = e.Result.getSearchCoordsResult;
        var pagedResults = JsonConvert.DeserializeObject<TestMap.Classes.Global.ResultSetPager<TestMap.Classes.Global.Place>>(response);
        Classes.Global.searched = 1;
        Results.ItemsSource = pagedResults.SearchResults;
        searchError.Text = "Search Result";
    }
    catch (Exception ex)
    {
        searchError.Text = "No Results Found";
    }
