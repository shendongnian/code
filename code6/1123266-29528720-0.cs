    public static class ContainsExtensions
    {
        public static bool ContainsAllOf(this string source, string toCompare, params string[] lineSeparators)
        {
            // split into parts.
            var srcParts = source.Split(lineSeparators, StringSplitOptions.RemoveEmptyEntries);
            var cmpParts = toCompare.Split(lineSeparators, StringSplitOptions.RemoveEmptyEntries);
            // check until candidate first matching source lines have been exhausted.
            var startLineNdx = 0;
            while (cmpParts.Length <= (srcParts.Length - startLineNdx))
            {
                // search for a match from the start of the current line.
                var matchNdx = srcParts[startLineNdx].IndexOf(cmpParts[0]);
                while (matchNdx >= 0)
                {
                    // Line has a match with the first line in cmpParts
                    // Check if all subsequent lines match from the same position.
                    var match = true;
                    for (var i = 1; i < cmpParts.Length; i++)
                    {
                        if (srcParts[startLineNdx + i].IndexOf(cmpParts[i], matchNdx) != matchNdx)
                        {
                            match = false;
                            break;
                        }
                    }
                    if (match) // all lines matched
                        return true;
                    // try to find a next match in this line.
                    matchNdx = srcParts[startLineNdx].IndexOf(cmpParts[0], matchNdx + 1);
                }
                // Try next line in source as matching start.
                startLineNdx++;
            }
            return false;
        }
    }
