         response.EnsureSuccessStatusCode();
    
         Task<Stream> result = response.Content.ReadAsStreamAsync();
    
         byte[] data = new byte[1028];
         int bytesRead;
         while ((bytesRead = await result.Result.ReadAsync(data, 0, data.Length)) > 0)
         {
            string output = System.Text.Encoding.UTF8.GetString(data, 0, bytesRead);
            Console.WriteLine(output);
         }
    
         Console.ReadKey();
