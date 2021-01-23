    IRestClient _restClient;
    RestRequest _request;
    PhoneNumber _phoneNumber;
    PhoneNumberVerificationResponse _responseData;
    public VerifyPhoneNumberConsumer(IRestClient client)
    {
        _restClient = client;
    }
    public void Consume(IConsumeContext<VerifyPhoneNumber> context)
    {
        try
        {
            //we can do some standard message verification/validation here 
            var response = await _restClient.ExecuteGetTaskAsync<PhoneNumberVerificationResponse>(_request);
            _responseData = response.Data;
            _phoneNumber = new PhoneNumber()
            {
                Number = _responseData.PhoneNumber
            };
        }
        catch (Exception exception)
        {
            context.Respond(new VerifyPhoneNumberFailed(context.Message)
            {
                PhoneNumber = context.Message.PhoneNumber,
                Message = exception.Message
            });
        }
    }
