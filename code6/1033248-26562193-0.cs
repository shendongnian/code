    private async Task readFile()
    {
        StorageFolder local = ApplicationData.Current.LocalFolder;
        if (local != null)
        {
            //...your code
            //Close the stream after using it
            msg.Close();
        }
    }
        
    private async Task createFile()
    {
        //...your code
        StorageFolder local = ApplicationData.Current.LocalFolder;
        //...your code
        //Close the stream after using it
        s.Close();
    }
