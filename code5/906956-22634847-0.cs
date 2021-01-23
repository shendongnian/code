    Stream stream = response.GetResponseStream();
    byte[] buffer = new byte[512];
    int bytesRead = 0;
    do
    {
        bytesRead = stream.Read(buffer, 0, buffer.Length);
        if (bytesRead > 0)
        {
            // Save the bytes to a memory stream
        }
    }
    while (bytesRead > 0 && !bw.CancellationPending)
    if (!bw.CancellationPending)
        img = Image.FromStream(<yourMemoryStream>);
