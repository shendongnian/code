    public async Task GetTimeTableAsync(string href, int day)
    {
        string htmlPage = string.Empty;
        using (var client = new HttpClient())
        {
            var response = await client.GetByteArrayAsync(URL);
    
            char[] decoded = new char[response.Length];
            for (int i = 0; i < response.Length; i++)
            {
                if (response[i] < 128)
                    decoded[i] = (char)response[i];
                else if (response[i] < 0xA0)
                    decoded[i] = '\0';
                else
                    decoded[i] = (char)iso8859_2[response[i] - 0xA0];
            }
            htmlPage = new string(decoded);
        }
    
        // further code... and on the end::
        TimeTableCollection.Add(xxx);
    } 
