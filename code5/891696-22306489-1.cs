        [Fact]
        public async Task Sending_same_content_multiple_times()
        {
            var client = new HttpClient { BaseAddress = _BaseAddress };
            var stream = new MemoryStream();
            var sw = new StreamWriter(stream);
            sw.Write("This is a stream");
            sw.Flush();
            stream.Position = 0;
            var multipart = new MultipartContent
            {
                new StringContent("This string will be sent repeatedly"),
                new FormUrlEncodedContent(new[] {new KeyValuePair<string, string>("foo", "bar"),}),
                new StreamContent(stream)
            };
            var content = new ReusableContent(multipart);
            for (int i = 0; i < 10; i++)
            {
                var response = await client.PostAsync("devnull", content);
                response.EnsureSuccessStatusCode();
            }
        }
