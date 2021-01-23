    using (MemoryStream imageStream = new MemoryStream())
    {
        imageStream = FetchImageStream(imageStream);
        if (imageStream != null)
        {
            // .... do whatever you intended to do with imageStream 
        }
    } // this way, it'll be destroyed with it goes out of scope
    public MemoryStream FetchImageStream(MemoryStream imageStream )
    {
        try
        {
            GetObjectResponse getObjectResponse = null; // This is NULL for example only
    
            using (BufferedStream bufferedStream = new BufferedStream(getObjectResponse.ResponseStream))
            {
                byte[] buffer = new byte[0x3000];
                int count;
                while ((count = bufferedStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    imageStream.Write(buffer, 0, count); // Write the image into memory stream
                }
            }
        }
        catch (Exception ex)
        {
            imageStream.Dispose();
            return null;
        }       
    
        return imageStream;
    }
