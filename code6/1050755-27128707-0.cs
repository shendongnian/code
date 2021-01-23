    string testJson = @"{
                          ""Fruits"": { ... }
                            ^--+-^
                               |
                               +-- this is assumed to be a property of this --+
                                                                              |
                                                     +------------------------+
                                                     |
                                                  v--+-v
    Fruits result = JsonConvert.DeserializeObject<Fruits>(testJson);
