    public class CompositeKeyPropertyRoutingConvention : PropertyRoutingConvention
    {
        public override string SelectAction(ODataPath odataPath, HttpControllerContext controllerContext, ILookup<string, HttpActionDescriptor> actionMap)
        {
            var action = base.SelectAction(odataPath, controllerContext, actionMap);
            return new CompositeKeyRoutingBehaviour().SelectAction(action, odataPath, controllerContext, actionMap);
        }
    }
    public class CompositeKeyRoutingBehaviour
    {
        public string SelectAction(string action, ODataPath odataPath, HttpControllerContext controllerContext,
                                   ILookup<string, HttpActionDescriptor> actionMap)
        {
            if (action != null)
            {
                var routeValues = odataPath.Segments.FirstOrDefault(x => x.SegmentKind == ODataRouteConstants.Key);
                if (routeValues != null)
                {
                    var keyRaw = routeValues.ToString();
                    var formatter = new KeyValueFormatter();
                    var keyPairs = formatter.FormatRawKey(keyRaw);
                    if (!keyPairs.Any())
                    {
                        return action;
                    }
                    foreach (var pair in keyPairs)
                    {
                        controllerContext.RouteData.Values.Add(pair.Key, pair.Value);
                    }
                }
            }
            return action;
        }
    }
    public class KeyValueFormatter
    {
        public IDictionary<string, string> FormatRawKey(string rawKey)
        {
            var formattedKeys = new Dictionary<string, string>();
            if (string.IsNullOrWhiteSpace(rawKey))
                return formattedKeys;
            var keyBuilder = new StringBuilder();
            var valueBuilder = new StringBuilder();
            var keyBuilding = true;
            var keys = new List<string>();
            var values = new List<string>();
            for (var i = 0; i < rawKey.Length; i++)
            {
                var currentChar = rawKey[i];
                var nextChar = i < rawKey.Length - 1 ? rawKey[i + 1] : (char?)null;
                var prevChar = i > 0 ? rawKey[i - 1] : (char?)null;
                if (currentChar == '=' && keyBuilding)
                {
                    keyBuilding = false;
                    
                    keys.Add(keyBuilder.ToString());
                    keyBuilder.Clear();
                    continue;
                }
                if (!keyBuilding && currentChar == ',' && prevChar.HasValue && prevChar.Value == '\'')
                {
                    keyBuilding = true;
                    values.Add(valueBuilder.ToString());
                    valueBuilder.Clear();
                    continue;
                }
                
                if (keyBuilding)
                {
                    keyBuilder.Append(currentChar);
                }
                else
                {
                    valueBuilder.Append(currentChar);
                }
                if (!keyBuilding && !nextChar.HasValue)
                {
                    values.Add(valueBuilder.ToString());
                    valueBuilder.Clear();
                }
            }
            if (keys.Count != values.Count)
            {
                throw new InvalidDataException("The key could not be formatted into valid pairs. key was: " + rawKey);
            }
            for (var i = 0; i < keys.Count; i++)
            {
                formattedKeys.Add(keys[i].Trim(), values[i].Trim());
            }
            return formattedKeys;
        }
    }
