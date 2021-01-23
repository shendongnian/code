    myDictionary = new Dictionary<string, MyDelegate> {
      { "ByTitle", repository.GetDetailsByTitle },
      { "ByTag", repository.GetDetailsByTag }
      /*etc*/
    };
