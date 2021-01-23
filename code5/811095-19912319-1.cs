    var inverseDictionary = yourDictionary.Select(key=>key.Value, value=>value.Key)
                                          .ToDictionary();
    //Then use it like this:
    long x;
    if(inverseDictionary.TryGetValue((string)events,out x)){
      var id = x.Value.ToString();
      //...
    }
