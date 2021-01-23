    int totalBytesToBeRead = ??; // somehow get length. responseStream.Length doesn't work.
    int totalBytesRead = 0;
    int bytesRead = -1;
    while (bytesRead != 0)
    {
        bytesRead = responseStream.Read(...);
        // now add to the total
        totalBytesRead += bytesRead;
        var progress = totalBytesRead * 100.0 / totalBytesToRead;
    }
