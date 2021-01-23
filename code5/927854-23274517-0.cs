        [HttpGet]
        public HttpResponseMessage Ping()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("X-Custom-Header", "This is my custom header.");
            response.Headers.Remove("Server");
            return response;
        }
