		[HttpGet]
        public HttpResponseMessage List()
        {
            try
            {
                var result = /*write code to fetch your result*/;
                return Request.CreateResponse(HttpStatusCode.OK, cruises);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
