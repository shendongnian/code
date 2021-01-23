    class SimpleObjectDeserialiser : Deserialiser<SimpleObject> {
        public SimpleObjectDeserialiser(SimpleJSONParser parser) : base(parser) {}
        public override SimpleObject Deserialise() {
            var properties = parser.Parse();
            bool isValid;
            var expectedProperties = new List<string> {"name", "age"};
            if (expectedProperties.Any(expectedProperty => !properties.AllKeys.Contains(expectedProperty))) {
                isValid = false;
            }
            else {
                isValid = true;
            }
            if (isValid) {
                return new SimpleObject
                {
                    Name = properties.Get("name"),
                    Age = Convert.ToInt32(properties.Get("age"))
                };
            }
            else {
                throw new JSONValidationException();
            }           
        }
    }
