    public static class StringExtensions
    {
        public static bool MultiContains(this string source, string compare)
        {
            if (source == null) return compare == null;
            if (compare == null) return false;
    
            var sourceParts = source.Split('\n');
            var compareParts = compare.Split('\n');
    
            if (sourceParts.Length != compareParts.Length) return false;
    
            // Try to get a match with the first pair of strings
            int firstMatchIndex = sourceParts[0].IndexOf(compareParts[0]);
    
            // If we didn't find any matches in the first pair, return false
            if (firstMatchIndex == -1) return false;
    
            var matched = false;
    
            // Otherwise, see if all compare matches are at same position
            while (!matched && firstMatchIndex > -1)
            {
                for (int i = 1; i < sourceParts.Length; i++)
                {
                    // See if we have a match in the same position as the first match
                    matched = sourceParts[i].IndexOf(compareParts[i], 
                        firstMatchIndex) == firstMatchIndex;
    
                    if (!matched)
                    {
                        // If one of the strings didn't match in the same position, 
                        // try to find another match in the first lines
                        firstMatchIndex = sourceParts[0].IndexOf(compareParts[0], 
                            firstMatchIndex + 1);
    
                        break;
                    }
                }
            }
            return matched;
        }
    }
