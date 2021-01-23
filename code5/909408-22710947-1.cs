      private void fError(int statusCode, string pErrorMessage)
        {
            throw new HttpResponseException((HttpStatusCode)statusCode)
            {
                Content = new StringContent(pErrorMessage),
                ReasonPhrase = "MyApplication Error"
            });
        }
