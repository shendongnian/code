    for (int i = 0; i < tokens.Count() - 1; i++)
    {
        if (one_gram.ContainsKey(tokens[i]))
        {
            one_gram[tokens[i]]++;
        }
        else
        {
            one_gram.Add(tokens[i], 1);
        }
        // Save yourself typing errors by creating the two gram key once
        // and then just referencing the variable that contains it.
        var twoGramKey = tokens[i] + " " + tokens[i + 1];
        if (two_gram.ContainsKey(twoGramKey))
        {
            two_gram[twoGramKey]++;
        }
        else
        {
             two_gram.Add(twoGramKey, 1);
        }
    }
