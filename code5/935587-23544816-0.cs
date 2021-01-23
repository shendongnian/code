    /// <summary>
    /// Workaround for handling double-click from the Map Results button - trying to prevent running the query twice and adding duplicate layers into the Layer Control
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void MapResultsButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ClickCount == 1)
    	    this.ViewModel.MapResultsCommand.Execute(null);
    } 
