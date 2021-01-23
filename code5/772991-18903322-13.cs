           public class MyServiceRunner<T> : ServiceRunner<T>
           {
        
                public override object HandleException(IRequestContext requestContext, T request, Exception ex)
                  {
                      if ( isYourCondition ) 
                      {
                            ResponseStatus rs = new ResponseStatus("error1", "your_message");
                            // optionally you can add custom response errors
                                 rs.Errors = new List<ResponseError>();
                                 rs.Errors.Add(new ResponseError());
                                 rs.Errors[0].ErrorCode = "more details 2";
                             
                                // create an ErrorResponse with the ResponseStatus as parameter
                                var errorResponse = DtoUtils.CreateErrorResponse(request, ex, rs);
                                 // log the error
                                 Log.Error("your_message", ex);
                                 return errorResponse;
                              
                       }
                       else
                            return base.HandleException(requestContext, request, ex);
                   }
                }
