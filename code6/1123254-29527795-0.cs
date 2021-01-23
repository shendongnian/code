    public static class StringExtensions
    {
        public static bool MultiContains(this string source, string other)
        {
            if (source == null) return other == null;
            if (other == null) return false;
            var firstParts = source.Split('\n');
            var secondParts = other.Split('\n');
            if (firstParts.Length != secondParts.Length) return false;
            // Try to get a match with the first pair of strings
            int firstMatchIndex = firstParts[0].IndexOf(secondParts[0]);
            // If we didn't find any matches in the first pair, return false
            if (firstMatchIndex == -1) return false;
            var matched = false;
            // Otherwise, see if all other matches are at same position
            while (!matched && firstMatchIndex > -1)
            {
                for (int i = 1; i < firstParts.Length; i++)
                {
                    // See if we have a match in the same position as the first match
                    matched = firstParts[i].IndexOf(secondParts[i], 
                        firstMatchIndex) == firstMatchIndex;
                    if (!matched)
                    {
                        // If one of the strings didn't match in the same position, 
                        // try to find another match in the first lines
                        firstMatchIndex = firstParts[0].IndexOf(secondParts[0], 
                            firstMatchIndex + 1);
                        break;
                    }
                }
            return matched;
        }
    }
