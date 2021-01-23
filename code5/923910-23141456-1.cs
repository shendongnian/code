    async Task<string> UploadFileAsync(string[] lst_path)
    {
        string uriString = "http://www.noelshack.com/api.php";
        string fileName = lst_path[0];
        using (HttpClient client = new HttpClient())
        using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
        using (MultipartFormDataContent form = new MultipartFormDataContent())
        using (StreamContent sc = new StreamContent(fs))
        {
            form.Add(sc, "fichier", fileName);
            HttpResponseMessage response = await client.PostAsync(uriString, form);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
