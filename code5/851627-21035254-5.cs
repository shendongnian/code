        private HttpClient client;
        public async Task<List<CommentsObject>> GetComments()
        {
            client = new HttpClient();
            var response = await client.GetAsync("http://www.reddit.com/r/AskReddit/comments/1ut6xc.json");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                List<CommentsObject> comments = await JsonConvert.DeserializeObjectAsync<List<CommentsObject>>(json);
                return comments;
            }
            else
            {
                throw new Exception("Errorhandling message");
            }
        }
