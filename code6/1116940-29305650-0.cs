        private static string ConvertToSafeName(string input)
        {
            var output = input;
            
            foreach (var lookup in GetLookups())
            {
                output = output.Replace(lookup.Key, lookup.Value);
            }
            return output;
        }
        private static string RevertToSpecialName(string input)
        {
            var output = input;
            foreach (var lookup in GetLookups())
            {
                output = output.Replace(lookup.Value, lookup.Key);
            }
            return output;
        }
        private static Dictionary<string, string> GetLookups()
        {
            Dictionary<string, string> lookups = new Dictionary<string, string>();
            lookups.Add("=", "_eq_");
            lookups.Add(">", "_gt_");
            lookups.Add("-", "_mn_");
            lookups.Add(" ", "__"); // double underscore for space
            return lookups;
        }
