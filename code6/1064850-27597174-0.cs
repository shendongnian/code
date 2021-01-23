    public string GetInvoiveNo(int id)
        {
            var uri = WebUrl + id;
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync(uri);
                
                return JsonConvert.DeserializeObjectAsync<string>(response.Result).Result;
            }
        }
