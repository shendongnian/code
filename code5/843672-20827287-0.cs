    private static Dictionary<char, char> BuildReplacementDictionary(Dictionary<char, double> analyzedSymbols,
                                                                     Dictionary<char, double> decodeSymbols)
    {
        Dictionary<char, char> replaceSymbols = new Dictionary<char, char>(analyzedSymbols.Count);
        foreach (KeyValuePair<char, double> analyzedKvp in analyzedSymbols)
        {
            double bestMatchValue = double.MaxValue;
            foreach (KeyValuePair<char, double> decodeKvp in decodeSymbols)
            {
                var testValue = Math.Abs(analyzedKvp.Value - decodeKvp.Value);
                if (testValue <= bestMatchValue)
                {
                    bestMatchValue = testValue;
                    replaceSymbols[analyzedKvp.Key] = decodeKvp.Key;
                }
            }
        }
        return replaceSymbols;
    }
