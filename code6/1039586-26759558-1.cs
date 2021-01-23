    public void LoadFile(string filePath)
    {
        BinaryFormatter formatter = new BinaryFormatter(); 
        if (File.Exists(filePath)) 
        { 
            try
            {
                using (Stream input = File.OpenRead(filePath))
                { 
                    // Whatever
                }
            }
                
            catch (Exception exception)
            {
                // Do something with exception -
                // could log and suppress, or rethrow,
                // or whatever you need.
            }
        } 
    }
