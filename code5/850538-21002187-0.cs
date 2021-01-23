    private Dictionary<string, string> SplitValuePairString(string originalString)
    {
        Dictionary<string, string> result = new Dictionary<string, string>();
        if (string.IsNullOrEmpty(originalString))
        {
            var keyValuePairs = originalString.Split(new char[] { '&' });
            foreach (string keyValuePair in keyValuePairs)
            {
                var parts = keyValuePair.Split(new char[] { '=' });
                if (parts.Length == 2)
                {
                    result.Add(parts[0], parts[1]);
                }
            }
        }
        return result;
    }
