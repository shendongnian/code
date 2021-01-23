            public string FromDictionaryToJson(Dictionary<string, string> dictionary)
            {
                var kvs = dictionary.Select(kvp => string.Format("\"{0}\":\"{1}\"", kvp.Key, string.Join(",", kvp.Value)));
                return string.Concat("{", string.Join(",", kvs), "}");
            }
    
            public Dictionary<string, string> FromJsonToDictionary(string json)
            {
                string[] keyValueArray;
                keyValueArray = json.Replace("{", string.Empty).Replace("}", string.Empty).Replace("\"", string.Empty).Split(',');
                return keyValueArray.ToDictionary(item => item.Split(':')[0], item => item.Split(':')[1]);
            }
