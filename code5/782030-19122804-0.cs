    private static void GetFile(string file, bool inBound)
    {
        // Removed the FTP setup code
        using (Stream responseStream = response.GetResponseStream())
        {
            using (Stream outputStream = File.OpenWrite(@".\" + file))
            {
                try
                {
                    responseStream.CopyTo(outputStream);
                }
                catch (Exception e)
                {
                    // Removed Exception code
                }
            }
        }
    }
