    void SharePage_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
    {
        DataRequest request = e.Request;
        //DataRequestDeferral defferal = request.GetDeferral();
        request.Data.Properties.Title = this.article.Title;
        request.Data.Properties.Description = this.article.Summary;
        request.Data.SetWebLink(new Uri(this.article.UrlDomain));
        //defferal.Complete();
    }
