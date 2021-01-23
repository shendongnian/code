    do
    {
        try
        {
            using (var stream = file.Open(FileMode.Append, FileAccess.Write,     FileShare.None))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    await writer.WriteLineAsync(data);
                }
            }
        }
        catch (IOException)
        {
            retryNeeded = true;
            retryLeft--;
            Thread.Sleep(500);
        }
        catch (Exception ex)
        {
            logger.ErrorException("Could not write to exception file: " + data, ex);
            throw;
        }
    }
    while (retryNeeded && retryLeft > 0);
