    public class PersonConverter : JsonCreationConverter<Person>
    {
        protected override Person Create(Type objectType, JObject jObject)
        {
            if (FieldExists("favoriteColor ", jObject))
            {
                return new Person() { favoriteColor = new ColorInfo() { Color = "Red" };
            }
        }
    
        private bool FieldExists(string fieldName, JObject jObject)
        {
            return jObject[fieldName] != null;
        }
    }
