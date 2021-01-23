    public class Parser
    {
        public Dictionary<int, Dictionary<string, int>> Parse(string input)
        {
            Dictionary<int, Dictionary<string, int>> data = new Dictionary<int, Dictionary<string, int>>();
            int? currentGroupKey = null;
            string[] keyValuePairs = input.Split(new char[] { ';' });
            foreach (var kvp in keyValuePairs)
            {
                string[] tokens = kvp.Split(new char[] { '-' });
                switch (tokens.Length)
                {
                    case 2:
                        {
                            if (currentGroupKey.HasValue)
                            {
                                int groupKey = currentGroupKey.Value;
                                AddKeyValuePair(data, groupKey, tokens[0], tokens[1]);
                            }
                            break;
                        }
                    case 3:
                        {
                            int groupKey;
                            if (int.TryParse(tokens[0], out groupKey))
                            {
                                currentGroupKey = groupKey;
                                AddKeyValuePair(data, groupKey, tokens[1], tokens[2]);
                            }
                            break;
                        }
                    default:
                        break;
                }
            }
            return data;
        }
        private void AddKeyValuePair(Dictionary<int, Dictionary<string, int>> data, int groupKey, string key, string val)
        {
            Dictionary<string, int> group;
            if (data.ContainsKey(groupKey))
            {
                group = data[groupKey];
            }
            else
            {
                group = new Dictionary<string, int>();
                data[groupKey] = group;
            }
            int intVal;
            if (int.TryParse(val, out intVal))
                group.Add(key, intVal);
        }
    }
