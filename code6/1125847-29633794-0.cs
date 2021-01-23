    Resource resource = new Resource(session);
    var allProps = resource.GetProperties();
            
    Console.WriteLine(
        "Culture (Best Guess via Spelling Langauge): " +
         allProps
             .Where(x => x.Name == "spellingdictionarylanguage")
             .Select(x => x.Value)
             .FirstOrDefault() ?? "");
            
