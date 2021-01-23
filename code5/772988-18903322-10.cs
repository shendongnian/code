           public class MyServiceRunner<T> : ServiceRunner<T>
           {
        
                public override object HandleException(IRequestContext requestContext, T request, Exception ex)
                  {
                      if ( isYourCondition ) 
                      {
                            ResponseStatus rs = new ResponseStatus("YourException", "your_log");
                            // optionally if anybody wants custom response errors
                                 rs.Errors = new List<ResponseError>();
                                 rs.Errors.Add(new ResponseError());
                                 rs.Errors[0].ErrorCode = "testCode123";
                             
                                // create errorResponse with the custom responseStatus
                                var errorResponse = DtoUtils.CreateErrorResponse(request, ex, rs);
                                 // log the error
                                 Log.Error("My Message", ex);
                                 return errorResponse;
                              
                       }
                       else
                            return base.HandleException(requestContext, request, ex);
                   }
                }
