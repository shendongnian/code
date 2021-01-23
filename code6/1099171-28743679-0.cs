    public class Country : XmlMethods<Country>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        private Country()
        {
        }
        private Country(int id, string code, string name)
        {
            Id = id;
            Code = code;
            Name = name;
        }
        public static Country Load(int countryId)
        {
            //test implementation
            return new Country(
                    1,
                    "some",
                    "someother");
        }
    }
    public class XmlMethods<T>
    {
        public XElement ToXElement()
        {
            StringBuilder xml = new StringBuilder();
            var xmlSerializer = new XmlSerializer(typeof(T));
            xmlSerializer.Serialize(new StringWriter(xml), this);
            return XElement.Parse(xml.ToString());
        }
    }
