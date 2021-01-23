    public override void Execute(IRequest req, IResponse res, object requestDto)
    {
        // Perform you filter actions
        if(authorised)
            return;
        // Not authorised, return some object
        var responseDto = new {
            SomeValue = "You are not authorised to do that."
        };
        // Set the status code
        res.StatusCode = (int)HttpStatusCode.Unauthorized;
        // You may need to handle other return types based on `req.AcceptTypes`
        // This example assumes JSON response.
        // Set the content type
        res.ContentType = "application/json";
        // Write the object
        res.Write(responseDto.toJson());
        // End the request
        req.EndRequest();
    }
