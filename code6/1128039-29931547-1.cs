        public HttpResponseMessage Get()
        {
            string content = "Your JSON content";
            return BuildResponseWithoutQuotationMarks(content);
        }
        
        private HttpResponseMessage BuildResponseWithoutQuotationMarks(string content)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(content);
            return response;
        }
        private HttpResponseMessage BuildResponseWithQuotationMarks(string content)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, content);
            return response;
        }
