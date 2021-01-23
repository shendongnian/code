    public static class JHelper
    {
        public static bool IsMale(this JObject person)
        {
            return ((JProperty)person.Parent.Parent).Name == "men";
        }
    }
