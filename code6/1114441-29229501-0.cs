    var output;
    dynamic jObject = JsonConvert.DeserializeObject (outputAPI);
    bool isArray = jObj.enrollDeviceErrorResponse.Type == JTokenType.Array;
    bool isObject = jObj.enrollDeviceErrorResponse.Type == JTokenType.Object;
    if(isObject)
       output = JsonConvert.DeserializeObject<EnrollDeviceErrorResponse>(outputAPI);
    //else you will use the other class to deserialize the object
