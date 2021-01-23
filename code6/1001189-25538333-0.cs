    string agent = WebOperationContext.Current.IncomingRequest.Headers["User-Agent"];
    if (agent.Contains("MSIE") == false)
    {
        WebOperationContext.Current.OutgoingResponse.ContentType = "application/octet-stream";
        WebOperationContext.Current.OutgoingResponse.Headers.Add("Content-Disposition", "inline; filename=\"{0}\"".Fill(attachment.Filename));
    }
    else
    {
        WebOperationContext.Current.OutgoingResponse.ContentType = "application/octet-stream";
        WebOperationContext.Current.OutgoingResponse.Headers.Add("Content-Disposition", "attachment; filename=\"{0}\"".Fill(attachment.Filename));
        WebOperationContext.Current.OutgoingResponse.Headers.Add("X-Download-Options", "noopen");
        WebOperationContext.Current.OutgoingResponse.Headers.Add("X-Content-Type-Options", "nosniff");
    }
    return new MemoryStream(attachment.Data);
