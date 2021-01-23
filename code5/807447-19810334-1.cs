                catch (WebServiceException err)
            {
            if (err.ErrorCode == "APIException" && err.ResponseStatus.Errors != null &&  
                       err.ResponseStatus.Errors.Count > 0)
                {
                     string  error_code = err.ResponseStatus.Errors[0].ErrorCode;
                       string field = err.ResponseStatus.Errors[0].FieldName;  
                      string  detailerror = err.ResponseStatus.Errors[1].ErrorCode;                   
                    
                }
