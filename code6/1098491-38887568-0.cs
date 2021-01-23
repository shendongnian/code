     public class HttpResponseBadRequestException: HttpResponseException
    {
        /// <summary>
        /// Basic
        /// </summary>
        public HttpResponseBadRequestException()
            : this(string.Empty)
        {
        }
        /// <summary>
        /// Specific Constructor. Use this to send a Bad request exception
        /// with a custom message
        /// </summary>
        /// <param name="message">The message to be send in the response</param>
        public HttpResponseBadRequestException(string message)
            : base(new HttpResponseMessage(HttpStatusCode.BadRequest) {
                Content = new StringContent(message) })
        {
        }
    }
