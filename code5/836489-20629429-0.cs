    class Address {
      public string street {get; private set;}
      public string city {get; private set;}
      public AddressTypes AddressType {get; private set;} // an enum to differentiate 
                                                          // "home address", "legal address"
      ...
    }
