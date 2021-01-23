    public static class JsonHelper
    {
        public static JEnumerable<JToken> TreatAsArray(this JToken token)
        {
            if (token.Type == JTokenType.Array)
            {
                return token.Children();
            }
            else
            {
                return new JEnumerable<JToken>(new List<JToken> { token });
            }
        }
    }
