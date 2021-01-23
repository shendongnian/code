    public HttpResponseMessage Get()
            {
                HttpResponseMessage response;
    
                var students = _starterKitUnitOfWork.StudentRepository.Get();
    
                if (students == null)
                {
                    response = new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, students);
                    response.Content.Headers.Expires = new DateTimeOffset(DateTime.Now.AddSeconds(300));
                }
                return response;
            }
