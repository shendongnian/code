    public static class JsonHelper
    {
        public static IEnumerable<JToken> TreatAsArray(this JToken token)
        {
            if (token.Type == JTokenType.Array)
            {
                return token.Children();
            }
            else
            {
                return new List<JToken> { token };
            }
        }
    }
