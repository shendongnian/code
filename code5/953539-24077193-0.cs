    var questions = xdoc.Root.Elements("chantier")
                        .Elements("questions").FirstOrDefault();
    if (questions != null)
    {
        var sitePreparation = questions.Element("sitePreparation");
        if (sitePreparation != null)
        {
            Console.WriteLine((string)sitePreparation.Element("P1_Question"));
            Console.WriteLine((string)sitePreparation.Element("P6_Question"));
        }
    }
