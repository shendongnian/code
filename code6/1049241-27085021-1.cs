    for (int i = 0; i < tokens.Count() - 1; i++)
    {
        // Save yourself typing errors by creating variables to hold 
        // the key values and then you can just use the variable name
        var oneGramKey = tokens[i];
        var twoGramKey = string.Format("{0} {1}", tokens[i], tokens[i + 1]);
        if (one_gram.ContainsKey(oneGramKey))
        {
            one_gram[oneGramKey]++;
        }
        else
        {
            one_gram.Add(oneGramKey, 1);
        }
        if (two_gram.ContainsKey(twoGramKey))
        {
            two_gram[twoGramKey]++;
        }
        else
        {
             two_gram.Add(twoGramKey, 1);
        }
    }
