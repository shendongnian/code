    do
    {
        try
        {
            if (retryNeeded)
                await Task.Delay(500); // substituted for Thread.Sleep
            using (var stream = file.Open(FileMode.Append, FileAccess.Write, FileShare.None))
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
        }
        catch (Exception ex)
        {
            logger.ErrorException("Could not write to exception file: " + data, ex);
            throw;
        }
    } while (retryNeeded && retryLeft > 0);
    return (retryLeft > 0);
