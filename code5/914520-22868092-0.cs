    string webResponse = "your long web response from the server";
    webResponse = webResponse.Replace(@"\/", "/");
    // If dynamic isn't in the phone subset, you'll need a class here containing "d" as a string.
    var jsonOuter = JsonConvert.DeserializeObject<dynamic>(webResponse);
    var jsonInner = JsonConvert.DeserializeObject<RootObject>(jsonOuter.d);
    if (jsonInner.UserId > .....)
