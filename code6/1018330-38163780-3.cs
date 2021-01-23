        var bytes = ToBytes(requestPayload);
        webRequest.Method = method;
        webRequest.Timeout = 2000;
        webRequest.ContentType = contentType;
        webRequest.Headers.Add("X-Amz-date", requestDate);
        webRequest.Headers.Add("Authorization", authorization);
        webRequest.Headers.Add("x-amz-content-sha256", hashedRequestPayload);
        webRequest.ContentLength = bytes.Length;
        using (Stream newStream = webRequest.GetRequestStream())
        {
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Flush();
        }
