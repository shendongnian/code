    HttpResponse performOperation(IServiceClient injectedServiceClient)
    {
        ServiceClient client = injectedServiceClient;
        try
        {
            client.Operation();
        }
        catch(CommunicationException ex)
        {
            // Handle Exception
        }
        catch(TimeoutException ex)
        {
            // Handle Exception
        }
        catch(Exception ex)
        {
            // Handle Exception
        }
        return httpResponse(httpStatusCode.OK);
    }
