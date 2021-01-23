    public class DictionaryConverter : JsonConverter
    {
        public DictionaryConverter()
        {
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //I've not implemented writing the Json
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            //create a new object
            var temp = new DataSourceRequestParams();
            temp.Sorting = new Dictionary<string, string>();
            temp.Filter = new Dictionary<string, string>();
            temp.Order = new Dictionary<string, string>();
            //load the input into a JObject and grab the "simple" values
            JObject jsonObject = JObject.Load(reader);
            temp.Page = jsonObject["page"].Value<int>();
            temp.Count = jsonObject["count"].Value<int>();
            //parse the dictionary values
            AddValuesToDictionary(temp, jsonObject, "sorting", temp.Sorting);
            AddValuesToDictionary(temp, jsonObject, "filter", temp.Filter);
            AddValuesToDictionary(temp, jsonObject, "order", temp.Order);
            return temp;
        }
        private void AddValuesToDictionary(DataSourceRequestParams test, JObject jsonObject, string name, IDictionary<string, string> dictionary)
        {
            //grab each matching property
            var properties = jsonObject.Properties().Where(j => j.Name.StartsWith(name));
            if (properties != null)
            {
                foreach (var property in properties)
                {
                    /*for each matched property grab the value between the brackets 
                     * from the name and the property value
                     * and the associate json value and add it to the dictionary
                     */
                    dictionary.Add(Regex.Match(property.Name, @"\[([^\]]*)\]").Groups[1].Value, property.Value.Value<string>());                    
                }
            }
        }
        public override bool CanConvert(Type objectType)
        {
            //we can convert if the type is DataSourceRequestParams
            return typeof(DataSourceRequestParams).IsAssignableFrom(objectType);
        }
    }
