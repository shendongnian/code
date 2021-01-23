    // Get the response.
    WebResponse response = request.GetResponse ();
    // Display the status.
    Console.WriteLine (((HttpWebResponse)response).StatusDescription);
    // Get the stream containing content returned by the server.
    dataStream = response.GetResponseStream ();
    // Open the stream using a StreamReader for easy access.
    StreamReader reader = new StreamReader (dataStream);
    // Read the content.
    string responseFromServer = reader.ReadToEnd ();
    // Display the content.
    Console.WriteLine (responseFromServer);
    // Clean up the streams.
    reader.Close ();
    dataStream.Close ();
    response.Close ();
