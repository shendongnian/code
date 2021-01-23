    async private void button1_Click(object sender, EventArgs e)
    {
        var response = await UploadToImgUrl(filename, client_id);
    }
----
    async Task<ImgUrl.Response> UploadToImgUrl(string fname, string client_id)
    {
        string endPoint = "https://api.imgur.com/3/upload";
        var data = Convert.ToBase64String(File.ReadAllBytes(fname));
            
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Client-ID " + client_id);    
            var resp = await client.PostAsJsonAsync(endPoint, new { image = data, type= "base64", name = new FileInfo(fname).Name });
            var content  = await resp.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ImgUrl.Response>(content);
        }
    }
    public class ImgUrl
    {
        public class Data
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public int Datetime { get; set; }
            public string Type { get; set; }
            public bool Animated { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public int Size { get; set; }
            public int Views { get; set; }
            public int Bandwidth { get; set; }
            public string Deletehash { get; set; }
            public string Name { get; set; }
            public string Link { get; set; }
        }
        public class Response
        {
            public Data Data { get; set; }
            public bool Success { get; set; }
            public int Status { get; set; }
        }
    }
