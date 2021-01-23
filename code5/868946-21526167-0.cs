    var result = 
        pContext.LanguageLegislations.AsEnumerable()
                .SelectMany(ll => ll.LegislationCode.Split('|').Select(legCode => new
                {
                    LangCode = ll.LanguageCode,
                    LegCode = legCode
                }))
                .ToList();
