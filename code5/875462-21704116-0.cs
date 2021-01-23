       public HttpResponseMessage Options()
        {
            
            var response = new HttpResponseMessage();
            response.Headers.Add("Access-Control-Allow-Headers", Request.Headers.GetValues("Access-Control-Request-Headers").FirstOrDefault() );
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.Headers.Add("Access-Control-Allow-Method", "GET");
            return response;
         }
