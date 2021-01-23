    [XmlRootAttribute("Skills")]
    public class SkillCollection
    {
        //Not neccessary to use attributes if the Property name matches the XML element name
        [XmlElement(ElementName = "Fire")]
        public Skill Fire { get; [UsedImplicitly] set; }
        [XmlElement(ElementName = "Ice")]
        public Skill Ice { get; [UsedImplicitly] set; }
        //If all the skills were named the same I could deserialize into an array, as shown below
        //But then I would have no way to access each skill, in my code
        //[XmlArray]
        //public Skill[] SkillCollection { get; set; }
        //Factory-Model to create an instance of SkillCollection class
        public static object XmlSerializer_Deserialize(string path, Type toType)
        {
            var deserializer = new XmlSerializer(toType);
            using (TextReader reader = new StreamReader(path))
            {
                object s2 = deserializer.Deserialize(reader);
                if (s2 == null)
                    Console.WriteLine(@"  Deserialized object is null");
                else
                    Console.WriteLine(@"  Deserialized type: {0}", s2.GetType());
                return s2;
            }
        }
    }
