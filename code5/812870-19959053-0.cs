        public static bool CreateJson(ref Dictionary<string, object> values, string source)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(source))
            {
                var serializer = new JavaScriptSerializer();
                object json = serializer.DeserializeObject(source);
                values = json as Dictionary<string, object>;
                result = values != null;
            }
            return result;
        }
