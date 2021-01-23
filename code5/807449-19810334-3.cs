                catch (WebServiceException err)
            {
            if (err.ErrorCode == "APIException" && err.ResponseStatus.Errors != null &&  
                       err.ResponseStatus.Errors.Count > 0)
                {
                     string  error_code = err.ResponseStatus.Errors[0].ErrorCode;
                     string  path_info = err.ResponseStatus.Errors[0].FieldName;  
                    string detail_error = err.ResponseStatus.Errors[1].ErrorCode;                   
                    
                }
