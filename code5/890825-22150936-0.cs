    public class Person
    {
        public string name { get; set; }
        public string age { get; set; }
        public string gender { get; set; }
        public string getClassSerialized()
        {
            return new JavaScriptSerializer().Serialize(this);
        }
        public Person getClassDeserialized(string sSerializedClass)
        {
            return new JavaScriptSerializer().Deserialize<Person>(sSerializedClass);
        }
    }
