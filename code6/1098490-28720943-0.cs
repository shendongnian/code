     public class ApiExceptions : HttpResponseException
            {
                public ApiExceptions(string reason, HttpStatusCode code):base(code)
                {
                    var response = new HttpResponseMessage
                    {
                        StatusCode = code,
                        ReasonPhrase = reason,
                        Content = new StringContent(reason)
                    };
                    throw new HttpResponseException(response);
                }
            }
