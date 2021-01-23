    public class PersonConverter : JavaScriptConverter
    {
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            Person person = new Person();
            foreach (string key in dictionary.Keys)
            {
                var value = dictionary[key];
                switch (key)
                {
                    case "Name":
                        person.Name = (string)value;
                        break;
                    case "Age":
                        {
                            if (value is int)
                            {
                                person.Age = (int)value;
                            }
                            else
                            {
                                int age;
                                if (int.TryParse((string)dictionary[key], out age))
                                {
                                    person.Age = age;
                                } // else leave Age as null (or if int, leave as 0); alternatively put an else block here to set to value of your choice
                            }
                        }
                        break;
                }
            }
            return person;
        }
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override IEnumerable<Type> SupportedTypes
        {
            get
            {
                return new[] { typeof(Person) };
            }
        }
    }
