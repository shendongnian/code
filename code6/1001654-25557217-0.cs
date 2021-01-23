    var twiml = new TwilioResponse().Message("test");
    return TwilioResponse(twiml);
    private HttpResponseMessage TwilioResponse(TwilioResponse twilioResponse)
    {
        return new HttpResponseMessage()
        {
            Content = new StringContent(twilioResponse.ToString(), Encoding.UTF8, "text/xml"),
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }
