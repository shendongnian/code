        public override void OnException(HttpActionExecutedContext context)
        {
            HttpResponseMessage msg = new HttpResponseMessage();
            if (context.Exception is ApiException)
            {
                ApiException apex = context.Exception as ApiException;
                msg.StatusCode = apex.StatusCode;
                msg.Content = new StringContent(apex.Message);
                throw new HttpResponseException(msg);
            }
        }
