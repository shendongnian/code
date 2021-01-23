    public static void DeleteFileContaining(string targetDirectory, string wildcard)
    {
        Directory.GetFiles(targetDirectory).Where(j => j.Contains(wildcard)).ToList().ForEach(i =>
            {
                try
                {
                    File.Delete(i);
                }
                catch (Exception ex)
                {                        
                    //do something here on exception.
                }
            });
    }
