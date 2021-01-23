    if (client.Capabilities.HasFlag (Pop3Capabilities.Top)) {
        var headers = client.GetMessageHeaders (index);
        if (headers[HeaderId.Subject] == subject)
            message = client.GetMessage (index);
    }
