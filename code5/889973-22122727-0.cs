    public class UriWithOccurrence
    {
        public string UriString { get; set; }
        public int Occurrences { get; set; }
    }
    ...
    //Keep a global collection of URIs:
    _allUris = new List<UriWithOccurrence>();
    foreach (string uriStr in uriStrCollection)
    {
        var item = new UriWithOccurrence()
                   {
                       UriString = uriStr,
                       Occurrences = uriStrCollection.Count(s => (s == uriStr))
                   };
        _allUris.Add(item);
    }
