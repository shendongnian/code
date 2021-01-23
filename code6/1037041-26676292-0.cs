    public class PersonConverter : JsonCreationConverter<Person>
    {
        protected override Person Create(Type objectType, JObject jObject)
        {
            if (FieldExists("duration", jObject))
            {
                return new MediaObject();
            }
            else if (FieldExists("author", jObject))
            {
                return new CreativeObject();
            }
            else
            {
                return new Thing();
            }
        }
    
        private bool FieldExists(string fieldName, JObject jObject)
        {
            return jObject[fieldName] != null;
        }
    }
