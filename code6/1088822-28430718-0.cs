    public Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
    {
        // Let the action method execute, resulting in a serialized response
        var responseMessage = await continuation();
        if (responseMessage.Content is ObjectContent)
        {
            // Get the message content in its unserialized form, and choose formatter
            var content = responseMessage.Content as ObjectContent;
            var formatter = ResponseShouldBePascalCased(actionContext)
                            ? _pascalCasingFormatter
                            : _camelCasingFormatter;
            // Re-serialize content, with the correctly chosen formatter
            responseMessage.Content = new ObjectContent(content.ObjectType, content.Value, 
                                                        formatter);
        }
        // Return the (possibly) re-serialized message
        return responseMessage;
    }
