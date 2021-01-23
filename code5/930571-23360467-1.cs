    int totalBytesRead = 0;
    do
    {
        int bytesRead = s.Receive(buffer);
        totalBytesRead += bytesRead;
        if (bytesRead == 0)
        {
            // Stream was closed - no more bytes
            break;
        }
        else
        {
            // Write bytesRead bytes from buffer to memory stream
        }
    }
    while (totalBytesRead < expectedNumberOfBytes);
    if (totalBytesRead < expectedNumberOfBytes)
        throw new Exception("Premature end of transmission");
