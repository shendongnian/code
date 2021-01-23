    try {
    
    }
    catch(WebException ex) {
        if (ex.Status == WebExceptionStatus.Timeout) {
            // Retry logic
        }
        else {
            // return error
        }
    }
