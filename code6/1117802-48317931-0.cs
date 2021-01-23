        private static bool TryParseJSON(string json, out JObject jObject)
        {
            jObject = null;
            try
            {
                jObject = JObject.Parse(json);
            }
            catch
            {
            }
            return jObject != null;
        }
