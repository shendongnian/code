    var status = await UploadToImgUrl(filename,client_id);
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
            public string id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public int datetime { get; set; }
            public string type { get; set; }
            public bool animated { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public int size { get; set; }
            public int views { get; set; }
            public int bandwidth { get; set; }
            public object vote { get; set; }
            public object nsfw { get; set; }
            public string deletehash { get; set; }
            public string name { get; set; }
            public string link { get; set; }
        }
        public class Response
        {
            public Data data { get; set; }
            public bool success { get; set; }
            public int status { get; set; }
        }
    }
