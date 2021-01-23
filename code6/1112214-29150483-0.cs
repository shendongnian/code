    private static List<string> _errorList;
    
    public static void OpenAllLinksAndCheckOnErrors()
    {
    	_errorList = new List<string>();
    	
        var collectionReportsLinks = CollectionReportsLinks();
        foreach (string linkToReportPage in collectionReportsLinks)
        {
            Driver.Instance.Navigate().GoToUrl(linkToReportPage);
    		_errorList.AddRange(new[]{FindErrorsInReportPages()});
            
             //add a console message if you want
            //Assert.That(string.IsNullOrWhiteSpace(FindErrorsInReportPages()), "Error on page {0}", FindErrorsInReportPages()));
        }
    	
    	//Just failed the test if error occurs.
    	foreach(string error in _errorList)
    	{
    		if (string.IsNullOrWhiteSpace(error))
            {
    			Assert.Fail("Failure message");
            }
    	}
    }
