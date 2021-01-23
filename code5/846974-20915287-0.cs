        private enum PersonMethodProperties
        {
            FirstChildName,
            FirstChildDob,
            SecondChildName,
            SecondChildDob
        }
        private void PersonMethod()
        {
            var includedProperties = GetIncludePropertiesFromEnum(typeof(PersonMethodProperties));
            var person = repository.Find("123", includedProperties);
            var firstChildDob = person.GetProperty(PersonMethodProperties.FirstChildDob.ToString()).AsDateTime();
        }
        private List<string> GetIncludePropertiesFromEnum(Type propertiesEnumType)
        {
            var includedProperties = new List<string>();
            foreach (var name in Enum.GetNames(propertiesEnumType))
            {
                includedProperties.Add(name);
            }
            return includedProperties;
        }
