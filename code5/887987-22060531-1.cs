    public static HttpResponseMessage CreateResponse<T>(this HttpRequestMessage request, HttpStatusCode statusCode, T value, HttpConfiguration configuration)
    {
      if (request == null)
        throw Error.ArgumentNull("request");
      configuration = configuration ?? HttpRequestMessageExtensions.GetConfiguration(request);
      if (configuration == null)
        throw Error.InvalidOperation(SRResources.HttpRequestMessageExtensions_NoConfiguration, new object[0]);
      IContentNegotiator contentNegotiator = ServicesExtensions.GetContentNegotiator(configuration.Services);
      if (contentNegotiator == null)
      {
        throw Error.InvalidOperation(SRResources.HttpRequestMessageExtensions_NoContentNegotiator, new object[1]
        {
          (object) typeof (IContentNegotiator).FullName
        });
      }
      else
      {
        IEnumerable<MediaTypeFormatter> formatters = (IEnumerable<MediaTypeFormatter>) configuration.Formatters;
        ContentNegotiationResult negotiationResult = contentNegotiator.Negotiate(typeof (T), request, formatters);
        if (negotiationResult == null)
        {
          return new HttpResponseMessage()
          {
            StatusCode = HttpStatusCode.NotAcceptable,
            RequestMessage = request
          };
        }
        else
        {
          MediaTypeHeaderValue mediaType = negotiationResult.MediaType;
          return new HttpResponseMessage()
          {
            Content = (HttpContent) new ObjectContent<T>(value, negotiationResult.Formatter, mediaType),
            StatusCode = statusCode,
            RequestMessage = request
          };
        }
      }
