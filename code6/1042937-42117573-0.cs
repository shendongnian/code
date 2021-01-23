    private TwilioRestClient mTwilioClient;
    var listRequest = new MessageListRequest()
    {
        To = PhoneNumber,
        Count = mMessagesPerPage,
        DateSent = DateTime.Today.Subtract(TimeSpan.FromDays(mDaysToSearch)),
        DateSentComparison = ComparisonType.GreaterThanOrEqualTo,
    };
    var ret = mTwilioClient.ListMessages(options);
    // ret.Messages will now have your first page of messages
    
    // For your next page of results
    if (ret.NextPageUri != null)
    {
         ret.next_page_uri = ret.NextPageUri.ToString().Substring(11);
    }
    IRestResponse result = mTwilioClient.Execute(new RestSharp.RestRequest(ret.next_page_uri));
    // The classes provided by Twilio do not line up with the fields return in Json for some reason, so we have to massage the data a bit.
    result.Content = CleanupJsonContent(result.Content);
    // Deserialize the Json content into a class.
    var nextRet = JsonConvert.DeserializeObject<TwilioResponse>(result.Content);
    // Set the next_page_uri string value. We can't use the Uri class since it doesn't seem to be a valid Uri...
    nextRet.next_page_uri = nextRet.NextPageUri.ToString().Substring(11);
    private string CleanupJsonContent(string jsonContent)
    {
        string ret = jsonContent.Replace("date_sent", "DateSent");
        ret = ret.Replace("account_sid", "AccountSid");
        ret = ret.Replace("date_created", "DateCreated");
        ret = ret.Replace("date_updated", "DateUpdated");
        ret = ret.Replace("num_segments", "NumSegments");
        ret = ret.Replace("api_version", "ApiVersion");
        ret = ret.Replace("price_unit", "PriceUnit");
        ret = ret.Replace("error_code", "ErrorCode");
        ret = ret.Replace("error_message", "ErrorMessage");
        ret = ret.Replace("first_page_uri", "FirstPageUri");
        ret = ret.Replace("previous_page_uri", "PreviousPageUri");
        ret = ret.Replace("page_size", "PageSize");
        ret = ret.Replace("next_page_uri", "NextPageUri");
        ret = ret.Replace("num_pages", "NumPages");
        ret = ret.Replace("last_page_uri", "LastPageUri");
        return ret;
    }
