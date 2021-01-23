    private System.IO.Stream Upload(string url, string param1, Stream fileStream, byte[] fileBytes)
    {
        HttpContent stringContent = new StringContent(param1);
        HttpContent fileStreamContent = new StreamContent(fileStream);
        HttpContent bytesContent = new ByteArrayContent(fileBytes);
        
        using (HttpClient client = new HttpClient())
        {
            using (MultipartFormDataContent formData = new MultipartFormDataContent())
            {
                formData.Add(stringContent, "param1", "param1");
                formData.Add(fileStreamContent, "file1", "file1");
                formData.Add(bytesContent, "file2", "file2");
                
                using (MD5 md5Hash = MD5.Create())
                {
                    formData.Headers.ContentMD5 = md5Hash.ComputeHash(formData.ReadAsByteArrayAsync().Result);
                }
                
                var response = client.PostAsync(url, formData).Result;
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                
                return response.Content.ReadAsStreamAsync().Result;
            }
        }
    }
