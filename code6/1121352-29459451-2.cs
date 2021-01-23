    public class CustomConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException(); // since we don't need to write a serialize a class, i didn't implement it
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {        
            JObject jObject = JObject.Load(reader); // load the json string into a JObject
            foreach (KeyValuePair<string, JToken> jToken in jObject) // loop through the key-value-pairs
            {
                if(jToken.Key == "booster") // we have a fixed structure, so just wait for booster property 
                {
					// we take any entry in booster which is an array and select it (in this example: ['myth', 'mythic rare'])
                    var tokens = from entry in jToken.Value 
                        where entry.Type == JTokenType.Array
                        select entry;
					// let's loop through the array/arrays
                    foreach (var entry in tokens.ToList())
                    {
                        if (entry.Type == JTokenType.Array) 
                        {
							// now we take every string of ['myth', 'mythic rare'] and put it into newItems
                            var newItems = entry.Values<string>().Select(e => new JValue(e));
                            // add 'myth' and 'mythic rare' after ['myth', 'mythic rare']
							// now the json looks like:
							// {
							//    ...
							//    ['myth', 'mythic rare'],
							//    'myth',
							//    'mythic rare'
							// }
							foreach (var newItem in newItems)
                                entry.AddAfterSelf(newItem);
                            // remove ['myth', 'mythic rare']
							entry.Remove();
                        }
                    }
                }
            }
			// return the new target object, which now lets us convert it into List<string>
            return new MyObject
            {
                booster = jObject["booster"].Values<string>().ToList()
            };
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MyObject);
        }
    }
