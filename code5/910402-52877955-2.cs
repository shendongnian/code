    public HttpResponseMessage MyAction([FromBody] JObject json)
    {
      // Check if JSON from request body has been parsed correctly
      if (json == null) {
        var response = new HttpResponseMessage(HttpStatusCode.BadRequest) {
          ReasonPhrase = "Invalid JSON"
        };
        throw new HttpResponseException(response);
      }
      MyParameterModel param;
      try {
        param = json.ToObject<MyParameterModel>();
      }
      catch (JsonException e) {
        var response = new HttpResponseMessage(HttpStatusCode.BadRequest) {
          ReasonPhrase = String.Format("Invalid parameter: {0}", e.Message)
        };
        throw new HttpResponseException(response);
      }
      // ... Request handling goes here ...
    }
