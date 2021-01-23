    class WhateverMyThingIsNamed
    {
        public string Name { get; set; }
        public object[] Booster { get; set; }
        public IEnumerable<string> GetBooster()
        {
            foreach (var o in Booster)
            {
                if (o is string)
                {
                    yield return (string) o;
                }
                else if (o is JArray)
                {
                    foreach (var element in (JArray) o)
                    {
                        yield return element.Value<string>();
                    }
                }
                else
                {
                    throw new InvalidOperationException("Unexpected element");
                }
            }
        } 
    }
    ...
    var json = File.ReadAllText("json1.json");
    var data = new JsonSerializer().Deserialize<WhateverMyThingIsNamed>(new JsonTextReader(new StringReader(json)));
    var boosterList = data.GetBooster().ToList();
