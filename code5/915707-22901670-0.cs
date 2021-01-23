    try
    {
        foreach (string subDir in Directory.GetDirectories(path))
        {
            try
            {
                queue.Enqueue(subDir);
            }
            catch (Exception ex)
            {
                //Do whatever you want with the error.
            }
        }
    }
    catch (Exception ex)
    {
       Console.Error.WriteLine(ex);
    }
