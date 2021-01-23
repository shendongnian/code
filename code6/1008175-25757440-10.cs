      public class CustomJsonMediaFormatter : JsonMediaTypeFormatter
        {
    	 private JsonSerializerSettings _jsonSerializerSettings;
    
            public CustomJsonMediaFormatter ()
            {
                _jsonSerializerSettings = CreateDefaultSerializerSettings();
            }
    
      private object ReadFromStream(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
            {
    
    var contentHeaders = content == null ? null : content.Headers;
    
                // If content length is 0 then return default value for this type
                if (contentHeaders != null && contentHeaders.ContentLength == 0)
                {
                    return GetDefaultValueForType(type);
                }
    
                // Get the character encoding for the content
                var effectiveEncoding = SelectCharacterEncoding(contentHeaders);
    
                try
                {
                    using (var reader = (new StreamReader(readStream, effectiveEncoding)))
                    {
                        var json = reader.ReadToEnd();
                        var jo = JObject.Parse(json);
                               // jo has got your value=xyz manipulate and feed back.
                    }
                 }
