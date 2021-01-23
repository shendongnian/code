    public static IEnumerable<string> LazySplit(this string source, StringSplitOptions stringSplitOptions, params string[] separators)
    {
        var sourceLen = source.Length;
    
        bool IsSeparator(int index, string separator)
        {
            var separatorLen = separator.Length;
    
            if (sourceLen < index + separatorLen)
            {
                return false;
            }
    
            for (var i = 0; i < separatorLen; i++)
            {
                if (source[index + i] != separator[i])
                {
                    return false;
                }
            }
    
            return true;
        }
    
        var indexOfStartChunk = 0;
    
        for (var i = 0; i < source.Length; i++)
        {
            foreach (var separator in separators)
            {
                if (IsSeparator(i, separator))
                {
                    if (indexOfStartChunk == i && stringSplitOptions != StringSplitOptions.RemoveEmptyEntries)
                    {
                        yield return string.Empty;
                    }
                    else
                    {
                        yield return source.Substring(indexOfStartChunk, i - indexOfStartChunk);
                    }
    
                    i += separator.Length;
                    indexOfStartChunk = i--;
                    break;
                }
            }
        }
    
        if (indexOfStartChunk != 0)
        {
            yield return source.Substring(indexOfStartChunk, sourceLen - indexOfStartChunk);
        }
    }
