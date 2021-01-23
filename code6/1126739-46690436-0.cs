            var input = new Dictionary<string, string>();
            input.Add("application.shortName", "TestShortName");
            input.Add("application.longName", "TestLongName");
            input.Add("application.description", "TestDescription");
            input.Add("application.deepNode.evenDeeperNode", "Values so deep, you can see Adelle rolling");
            input.Add("common.yes", "YesTest");
            input.Add("common.no", "NoTest");
            input.Add("common.save", "SaveTest");
            input.Add("common.pager.pagesLenghtBefore", "LengthTestDeepNode");
            var res = new Dictionary<string, Object>();
            foreach(var pair in input)
            {
                var key = pair.Key;
                var parts = key.Split('.');
                var currentObj = res;
                for (int i = 0; i < parts.Length-1; i++)
                {
                    var property = parts[i];
                    if (!currentObj.Keys.Contains(property))
                        currentObj[property] = new Dictionary<string, Object>();
                    currentObj = (new Dictionary<string, Object>())currentObj[property];
                }
                currentObj[parts[parts.Length - 1]] = pair.Value;
            }
            var json = JsonConvert.SerializeObject(res, Formatting.Indented);
