    var codes = requestDictionary
                   //Extract all List<>s from the dictionary:
                   .Select(entry => entry.Value)
                   //Enumerate all the lists back-to-back and extract the SearchCode:
                   .SelectMany(tuple => tuple.Item2.SearchCode)
                   .ToArray();
