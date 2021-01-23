                public override object HandleException(IRequestContext requestContext, T request,    Exception ex)
        {
             APIException apiex = ex as APIException;    // custo application exception
            if (apiex != null)
            {
                ResponseStatus rs = new ResponseStatus("APIException", apiex.message);
                rs.Errors = new List<ResponseError>();
                rs.Errors.Add(new ResponseError());
                rs.Errors[0].ErrorCode = apiex.errorCode.ToString();               
                rs.Errors[0].FieldName = requestContext.PathInfo;
                 rs.Errors[1].ErrorCode = apiex.detailCode.ToString(); 
                // create an ErrorResponse with the ResponseStatus as parameter
                var errorResponse = DtoUtils.CreateErrorResponse(request, ex, rs);
              
                Log.Error("your_message", ex);   // log only the the error
                return errorResponse;
            }
            else
                return base.HandleException(requestContext, request, ex);
        }
     
