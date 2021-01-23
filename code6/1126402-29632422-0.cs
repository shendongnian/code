    public async Task FooAsync()
    {
        using (var client = new HttpClient())
        {
            HttpContent content = new ByteArrayContent(new byte[]{});
        
            await client.PostAsync("<valid http address>", content);
        
            // Continue your code here.
        }
    }
