    utilityClass.Retrieve_Completed += UtilityClassRetrieve_Completed;
    utilityClass.GetLatestHeadline();
    ...
    public void UtilityClassRetrieve_Completed(EventArgs e)
    {
        // Do something with your e.New value here in the view model
        LatestHeadlineProperty = e.New;
    }
