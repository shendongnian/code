    private async static void WriteToStreamFirstVariantSimplified()
    {
        using(MemoryStream memoryStream = new MemoryStream())
        {
            byte[] data = new byte[256];
            try
            {
                await memoryStream.WriteAsync(data, 0, data.Length);
            }
            catch(Exception exception)
            {
                //Handling exception
            }
       }
    }
