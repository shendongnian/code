    public static class JsonExtensions
    {
        public static JToken PromoteNamedPropertiesToParents(this JToken token, string propertyName)
        {
            return token.EditFields(pair =>
            {
                if (pair.Key == propertyName && pair.Value is JObject)
                {
                    return ((JObject)pair.Value).FlattenFields(pair.Key);
                }
                return pair.Yield();
            });
        }
    }
