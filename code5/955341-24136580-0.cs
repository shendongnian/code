        private static List<KeyValuePair<string, string>> ExtractData(string dataString, List<string> keys)
        {
            // Convert any leading "=" to another character avoid losing it :)
            dataString = dataString.Replace(",=", ",+");
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();
            // Split on equals and comma
            var entries = dataString.Split(new char[] { '=', ',' }, StringSplitOptions.RemoveEmptyEntries);
            // Start with null key
            string key = null;
            // Start with blank value for each key
            string value = "";
            foreach (string entry in entries)
            {
                // Put back any removed '='
                string text = entry.Replace('+', '=');
                if (keys.Contains(entry))
                {
                    // Save previous key value
                    if (!string.IsNullOrEmpty(value))
                    {
                        result.Add(new KeyValuePair<string, string>(key, value.TrimEnd(new char[] { ',' })));
                    }
                    key = entry;
                    value = "";
                }
                else
                {
                    value += text + ",";
                }
            }
            // save last result
            result.Add(new KeyValuePair<string,string>(key, value.TrimEnd(new char[]{','})));
            return result;
        }
