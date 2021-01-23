    var keyValuePairLines = File.ReadLines(pathInputFile)
        .Select(l =>
        {
            l = l.Replace("@VAR;", "").Replace("@ENDVAR;", "").Replace("Op==;", "");
            string[] tokens = l.Split(new[]{';'}, StringSplitOptions.RemoveEmptyEntries);
            var lineValues = new List<KeyValuePair<string, string>>();
            for(int i = 0; i < tokens.Length; i += 2)
            {
                // Value to a variable can be found on the next index, therefore i += 2
                string[] pair = tokens[i].Split('=');
                string key = pair.Last();
                string value = null;
                string nextToken = tokens.ElementAtOrDefault(i + 1);
                if (nextToken != null)
                { 
                    pair = tokens[i].Split('=');
                    value = pair.Last();
                }
                var keyVal = new KeyValuePair<string, string>(key, value);
                lineValues.Add(keyVal);
            }
            return lineValues;
        });
    
    File.WriteAllLines(pathOutputFile, keyValuePairLines.SelectMany(l => 
        l.Select(kv=>string.Format("{0} = {1}", kv.Key, kv.Value))));
