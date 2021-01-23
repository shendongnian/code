        public static JObject ParseWithMissingBraces(string json)
        {
            return JObject.Parse(AddMissingOuterBraces(json));
        }
        public static string AddMissingOuterBraces(string json)
        {
            for (int i = 0; i < json.Length; i++)
            {
                if (char.IsWhiteSpace(json[i])
                    || json[i] == '\t'
                    || json[i] == '\r'
                    || json[i] == '\n'
                    || json[i] == '\0')
                    continue;
                if (json[i] == '['
                    || json[i] == '{')
                    return json;
                return string.Format("{{{0}}}", json);
            }
            return json;
        }
