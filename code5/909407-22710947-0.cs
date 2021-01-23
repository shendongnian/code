      private void fError(HttpStatusCode statusCode, string pErrorMessage)
        {
            throw new HttpResponseException(statusCode)
            {
                Content = new StringContent(pErrorMessage),
                ReasonPhrase = "MyApplication Error"
            });
        }
