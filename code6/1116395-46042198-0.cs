    [WebInvoke(Method = "GET", UriTemplate = "GetFile/{BillingPeriodId}", RequestFormat = WebMessageFormat.Json)]
    public Stream GetFile(string BillingPeriodId)
    {
      WebOperationContext.Current.OutgoingResponse.ContentType = "application/pdf";
      WebOperationContext.Current.OutgoingResponse.Headers.Add("Content-Disposition", "attachment;inline; filename=pdf-test.
      Stream stream  = File.OpenRead(@"C:\pdf-test.pdf");   
      return stream;
    }
