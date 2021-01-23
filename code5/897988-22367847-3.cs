        protected void Application_Error()
        {
            Exception ex = Server.GetLastError();
            bool handleError = false;
            int errorCode = 500;
            if (handleError = (ex is InvalidOperationException && ex.Message.Contains("or its master was not found or no view engine supports the searched locations. The following locations were searched")))
            {
                errorCode = 404;
            }
            else if (handleError = ex is HttpException)
            {
                errorCode = ((HttpException)ex).GetHttpCode();
            }
            if (handleError)
            {
                Server.ClearError();
                Server.TransferRequest("/error/error/" + errorCode);
            }
        }
