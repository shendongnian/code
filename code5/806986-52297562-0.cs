         [HttpPost]
         public async Task<string> Post(Thing thing)
         {
             var content = "\r";
             var httpResponseMessage = Request.CreateResponse(HttpStatusCode.Accepted, content);
             var escapedString = await httpResponseMessage.Content.ReadAsStringAsync();
             return Content(escapedString, "application/json");            
         }  
