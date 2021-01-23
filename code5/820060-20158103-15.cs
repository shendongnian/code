    public static class JsonHelper
    {
        public static JArray ToJArray(this JToken token, string itemProperty)
        {
            if (token != null && token.Type != JTokenType.Null)
            {
                token = token[itemProperty];
                if (token != null)
                {
                    if (token.Type == JTokenType.Array)
                    {
                        return (JArray)token;
                    }
                    else
                    {
                        return new JArray(token);
                    }
                }
            }
            return new JArray();
        }
    }
