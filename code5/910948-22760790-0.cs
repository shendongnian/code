    public class Group
    {
       public string GroupName;
    
       public string Comment;
    }
    
    public class Test
    {
       public static void Main()
       {
          Test t = new Test();
          t.SerializeObject("IgnoreXml.xml");
       }
    
       public XmlSerializer CreateOverrider()
       {
          XmlAttributeOverrides xOver = new XmlAttributeOverrides();
          XmlAttributes attrs = new XmlAttributes();
    
          attrs.XmlIgnore = true; //Ignore the property on serialization
          xOver.Add(typeof(Group), "Comment", attrs);
    
          XmlSerializer xSer = new XmlSerializer(typeof(Group), xOver);
          return xSer;
       }
    
       public void SerializeObject(string filename)
       {
          // Create an XmlSerializer instance.
          XmlSerializer xSer = CreateOverrider();
    
          Group myGroup = new Group();
          myGroup.GroupName = ".NET";
          myGroup.Comment = "My Comment...";
    
          TextWriter writer = new StreamWriter(filename);
    
          xSer.Serialize(writer, myGroup);
          writer.Close();
       }
