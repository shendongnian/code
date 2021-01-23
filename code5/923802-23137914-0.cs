    List<int> arrCMs = strMyList.Split(',')
        .Select(possibleIntegerAsString => {
            int parsedInteger = 0;
            bool isInteger = int.TryParse(possibleIntegerAsString , out parsedInteger);
            return new {isInteger, parsedInteger};
        })
        .Where(tryParseResult => tryParseResult.isInteger)
        .Select(tryParseResult => tryParseResult.parsedInteger)
        .ToList();
