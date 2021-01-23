    public static void OpenAllLinksAndCheckOnErrors()
    {  var errorsList as new List<string>
       var collectionReportsLinks = CollectionReportsLinks();
       foreach (string linkToReportPage in collectionReportsLinks)
        {
           Driver.Instance.Navigate().GoToUrl(linkToReportPage);
           errorsList.Add(FindErrorsInReportPages())
        }  
       Assert.That(errorsList, Is.All.Null)
    }
