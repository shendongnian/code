    // Gets current selection.
    public DbConnect.PlotList SelectedPlotList
    {
    	get
    	{
    		return PlotListView.SelectedItem as DbConnect.PlotList;
    	}
    }
    public void ResetPlot(int filterReference)
    {
        // Get current plot number;
    	int? plotNumber = SelectedPlotList == null ? (int?)null : SelectedPlotList.PlotNumber;
    	
        var dbObject = new DbConnect();
        dbObject.OpenConnection();
    
        List<DbConnect.PlotList> plotList = dbObject.SelectPlotLists(filterReference);
        // Find the plot list in the new list.	
    	DbConnect.PlotList selectPlotList = 
    		plotNumber.HasValue
    		? plotList.Where(x => x.PlotNumber == plotNumber.Value).FirstOrDefault();
    		: null;
        Dispatcher.BeginInvoke(new ThreadStart(() => PlotListView.ItemsSource = plotList));
        // Re-select plot list if found in the new list.
    	if (selectPlotList != null)
    	{
    		PlotListView.SelectedItem = selectPlotList;
    	}
        int jobSum = 0;
        int bidSum = 0;
    	
    	
        foreach (DbConnect.PlotList item in PlotListView.Items)
        {
            jobSum += Convert.ToInt32(item.Jobs);
            bidSum += Convert.ToInt32(item.Bids);
        }
    
        Dispatcher.BeginInvoke(
            new ThreadStart(() => JobBidRatioTextBlock.Text = jobSum + " jobs - " + bidSum + " bids"));
    }
