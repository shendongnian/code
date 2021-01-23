    // true if the collection is changed, false otherwise
    public Boolean ApplyDefaults(IList<CountryDto> dtos) {
      Boolean result = false;
      //Iterates the collection
      //Validates the items in collection
      //If items are invalid:
      //  Removes items e.g dtos.Remove(currentCountryDto)
      //  result = true;
      ...
      return result; 
    }
    ...
    if (ApplyDefaults(myData)) {
      // Collection is changed, do some extra stuff
    }
