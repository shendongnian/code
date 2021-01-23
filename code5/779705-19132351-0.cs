    public static ActionResult HandleException(Exception e)
            {
                try
                {
                    //Calling the EL exception handler block. Configured to rethrow a HandledException.
                    ExceptionPolicy.HandleException(e, ExceptionPolicyName.StatusCodePolicy.GetCode());
                    //If no exception happened, that is a problem. Internal Server Error, also logging should be done.
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
                }
                //Catch the HandledException. It contains only controlled info on the error, which can be sent to the client. Also, the original exception is already logged by this time.
                catch (HandledException ex)
                {              
                    return new HttpStatusCodeResult(ex.StatusCode, ex.Message);
                }
                catch (Exception ex)
                {
                    //If the exception was not a HandledException (very unlikely), that is a problem, it should be logged. Also, Internal Server Error.
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
                }
            }
