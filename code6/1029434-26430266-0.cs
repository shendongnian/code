    public class Serializer
    {
        private static string Serialize(Base baseData)
        {
            var mappedBase = new Base();
            // Do mapping
            mappedBase.Foo = baseData.Foo;
    
            var serializer = new XmlSerializer(typeof(Base));
            var sb = new StringBuilder();
            using (var writer = XmlWriter.Create(sb))
            {
                serializer.Serialize(writer, mappedBase);
            }
            return sb.ToString();
        }
    
        private static string Deserialize(...) { ... }
    }
