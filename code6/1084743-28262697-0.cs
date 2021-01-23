    private void Serialize()
    {
        using (FileStream fs = new FileStream("person.xml", FileMode.Create))
        {
            XmlSerializer serializer = new XMLSerializer(typeof(Person));
            serializer.Serialize(fs, this);
        }
    }
    public static Person Deserialize(string filename = "person.xml")
    {
        using (FileStream fs = new FileStream(filename, FileMode.Open))
        {
            XmlSerializer serializer = new XMLSerializer(typeof(Person));
            return (Person)serializer.Deserialize(fs);
        }
    }
