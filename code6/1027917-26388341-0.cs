        public static XmlSerializer CreateSerializer(Type incomingType, IEnumerable<Type> knownTypes = null)
        {
            XmlSerializer output;
            output = new XmlSerializer(incomingType, knownTypes.ToArray());
            return output;
        }
        public static T FromXml<T>(this string input, params Type[] knownTypes)
        {
            T output;
            var serializer = CreateSerializer(typeof(T), knownTypes);
            output = (T)serializer.Deserialize(new StringReader(input));
            return output;
        }
        var p = File.ReadAllText(@"testproject.xml").FromXml<Project>(typeof(RestRequestStep));
