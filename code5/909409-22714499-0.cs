        public static void fError(string pErrorMessage, int pStatusCode)
        {
            throw new HttpResponseException(new HttpResponseMessage
            {
                StatusCode = (HttpStatusCode)pStatusCode,
                Content = new StringContent(pErrorMessage),
                ReasonPhrase = "MyApplication Error"
            });
        }
