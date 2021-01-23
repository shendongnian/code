        [HttpPost]
        public HttpResponseMessage Post(string score)
        {
            ////DO SOMETHING WITH SCORE
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
            response.Content = new StringContent("Score Saved", Encoding.Unicode);
            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
            MaxAge = TimeSpan.FromMinutes(20)
            };
            return response;
        }
