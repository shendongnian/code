    protected override void WriteFile(HttpResponseBase response)
    {
        Stream outputStream = response.OutputStream;
        using (this.FileStream)
        {
            byte[] buffer = new byte[0x1000];
            while (true)
            {
                int count = this.FileStream.Read(buffer, 0, 0x1000);
                if (count == 0)
                {
                    return;
                }
                outputStream.Write(buffer, 0, count);
            }
        }
    }
