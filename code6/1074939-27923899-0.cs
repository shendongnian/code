    [Route("UploadCFTCFiles")]
        [HttpPost]
        public void UploadCftcFiles(HttpRequestMessage request)
        {
            Stream stream = new MemoryStream();
            var task = request.Content.ReadAsByteArrayAsync();
            task.Wait();
            var buffer = task.Result;
            stream.Write(buffer, 0, buffer.Length);
            _client.UploadCftcFiles(stream);
        }
