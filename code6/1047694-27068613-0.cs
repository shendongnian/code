    public async Task<HttpResponseMessage> Get(HttpRequestMessage request, int id)
        {
            byte[] img = await _repo.GetImgAsync(id);//gets image from database.
            HttpResponseMessage msg = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(img)
            };
            msg.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            return msg;
        }
