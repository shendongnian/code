        public void Traverse(string name, JToken j)
        {
            foreach (JToken token in j.AsJEnumerable())
                if (token.Type == JTokenType.Object)
                {
                    foreach (var pair in token as JObject)                        
                    {
                        string name_ = pair.Key;
                        JToken child = pair.Value;
                        Traverse(name, child);
                    }
                }
                else if (token.Type == JTokenType.Array) //an array property found 
                {
                    foreach (var child in token.Children())
                        Traverse(((JProperty)j).Name, child);
                }
                else if (token.Type == JTokenType.Property)
                {
                    var property = token as JProperty; //current level property
                    Traverse(name, (JContainer)token);
                }
                else //current level property name & value
                {
                    var nm = "";
                    var t = "";
                    if (j is JProperty)
                    {
                        nm = ((JProperty)j).Name;
                        t = Convert.ToString(((JProperty)j).Value);
                    }
                    t = Convert.ToString(token);
                }
        }
