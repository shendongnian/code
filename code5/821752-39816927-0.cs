    string SubstringBetweenSymbols(string str, char preSymbol, char postSymbol)
        {
            int? preSymbolIndex = null;
            int? postSymbolIndex = null;
            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0 && preSymbol == char.MinValue)
                {
                    preSymbolIndex = -1;
                }
                if (str[i] == preSymbol && !(preSymbolIndex.HasValue && preSymbol == postSymbol))
                {
                    preSymbolIndex = i;
                }
                if (str[i] == postSymbol && preSymbolIndex.HasValue && preSymbolIndex != i)
                {
                    postSymbolIndex = i;
                }
                if (i == str.Length - 1 && postSymbol == char.MinValue)
                {
                    postSymbolIndex = str.Length;
                }
                if (preSymbolIndex.HasValue && postSymbolIndex.HasValue)
                {
                    var result = str.Substring(preSymbolIndex.Value + 1, postSymbolIndex.Value - preSymbolIndex.Value - 1);
                    return result;
                }
            }
            return string.Empty;
        }
