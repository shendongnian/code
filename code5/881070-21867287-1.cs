    var codes = requestDictionary
                   //Extract all List<>s from the dictionary and enumerate them back-to-back:
                   .SelectMany(entry => entry.Value)
                   //Extract the SearchCode from each list item:
                   .Select(tuple => tuple.Item2.SearchCode)
                   .ToArray();
