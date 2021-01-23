    class StartPageData : PageData
    {
        // Could easily be a ContentArea or other type
        public virtual string SiteMessage { get; set; }
    }
    // In you masterpage or some other suitable place
    var startPage = DataFactory.Instance.Get<StartPageData>(PageReference.StartPage);
    var siteMessage = startPage.SiteMessage;
    // display siteMessage
