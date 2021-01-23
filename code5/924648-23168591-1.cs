        using IvanAkcheurov.NTextCat.Lib;
        // ....
        // <YOUR CODE>
        // ....
        var factory = new RankedLanguageIdentifierFactory();
        var identifier = factory.Load("NTextCat 0.2.1.1\\LanguageModels\\Core14.profile.xml");
        var languages = identifier.Identify("your text to get its language identified");
        var mostCertainLanguage = languages.FirstOrDefault();
        if (mostCertainLanguage != null)  
            Console.WriteLine("The language of the text is '{0}' (ISO639-3  code)",mostCertainLanguage.Item1.Iso639_3);  
        else 
            Console.WriteLine("The language couldn’t be identified with an acceptable degree of certainty");
