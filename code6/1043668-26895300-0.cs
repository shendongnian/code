    try
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open(configData.RxOutFn, FileMode.Create)))
        {
            // Do something                    
        }
    }
    catch (IOException e)
    {
        // Display error
    }
