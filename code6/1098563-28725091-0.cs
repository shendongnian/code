    public async Task Consume(ConsumeContext<VerifyPhoneNumber> context)
    {
        try
        {
            var response = await _restClient
                .ExecuteAsync<PhoneNumberVerificationResponse>(_request);
            var phoneNumber = new PhoneNumber()
            {
                Number = response.PhoneNumber
            };
            await context.RespondAsync(new VerifyPhoneNumberSucceeded(context.Message)
            {
                PhoneNumber = _phoneNumber
            });
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
