    Section section = new Section();
    List<Dataset> sectionAsList = section; // Legal
    List<Dictionary<string, string>> sectionAsListDictionary = section; // Illegal
    IList<Dictionary<string, string>> sectionAsIListDictionary = section; // Illegal
    IEnumerable<Dictionary<string, string>> sectionAsIEnumerableDictionary = section; // Legal
