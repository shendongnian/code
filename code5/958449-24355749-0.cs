    return new Response
    {
        StatusCode = HttpStatusCode.PartialContent,
        ContentType = "audio/mp3",
        Headers =
        {
            new KeyValuePair<string, string>("Accept-Ranges", "bytes"),
            new KeyValuePair<string, string>("Content-Range", string.Format("bytes {0}-{1}/{2}", startPosition, endPosition , totalLength)),
            new KeyValuePair<string, string>("Content-Length", outputBytes.Length.ToString(CultureInfo.InvariantCulture))
        },
        Contents = s =>
        {
            // I can write here multiple times thus sending multiple chunks
            s.Write(outputBytes, 0, takeHowMuch);
            s.Write(otherOutputBytes, 0, takeHowMuch);
        }
    };
