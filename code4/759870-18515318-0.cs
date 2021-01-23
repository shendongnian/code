    public class PersonWithNullProperties
    {
        public string Name { get; set; }
        public int? Age { get; set; }
        public bool ShouldSerializeAge()
        {
            return true;
        }
    }
      PersonWithNullProperties nullPerson = new PersonWithNullProperties() { Name = "ABCD" };
      XmlSerializer xs = new XmlSerializer(typeof(nullPerson));
      StringWriter sw = new StringWriter();
      xs.Serialize(sw, nullPerson);
