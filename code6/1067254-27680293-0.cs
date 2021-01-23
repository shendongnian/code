        public async Task<List<superclass2.Now>> GetComments()    
        {
            client = new HttpClient();
            var response = await client.GetAsync(new Uri("http://api.yousee.tv/rest/tvguide/nowandnext/"));
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine(json);
                var task = Task.Factory.StartNew(() => JsonConvert.DeserializeObject<superclass2.RootObject>(json));
                var value = await task;
                System.Diagnostics.Debug.WriteLine("Comments er lavet");
                return (value == null ? null : value.now);
            }
            else
            {
                throw new Exception("Errorhandling message");
            }
        }
    
