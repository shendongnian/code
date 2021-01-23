    // Get IEnum<string>, one SQL command per string
    // NB. enumerating a dictionary gives IEnum<KeyValuePair<TKey, TVal>>
    var exprs = myDictionary.Select(kv =>
                    // Build SQL
                );
    var cmdStr = String.Join("\r\n", exprs);
