    private string ToPercentEncoding(List<KeyValuePair<string, string>> pairs)
    {
        List<string> joinedPairs = new List<string>();
        foreach (var pair in pairs)
        {
            joinedPairs.Add(
                System.Net.WebUtility.UrlEncode(pair.Key) +
                "=" +
                System.Net.WebUtility.UrlEncode(pair.Value));
        }
        return String.Join("&", joinedPairs);
    }
