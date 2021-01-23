    public HttpResponseMessage GetTestData()
            {        
                   var testdata = (from u in context.TestRepository.Get().ToList()                            
                                select
                                     new Message
                                     {
                                         msgText = u.msgText                                    
                                     });    
                    return ActionContext.Request.CreateResponse(HttpStatusCode.OK, testdata);
            }
