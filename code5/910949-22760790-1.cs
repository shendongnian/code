    public class GroupBase
    {
        public string GroupName;
        public string Comment;
    }
    public class GroupDerived : GroupBase
    {	
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
          xOver.Add(typeof(GroupDerived), "Comment", attrs);
    
          XmlSerializer xSer = new XmlSerializer(typeof(GroupDerived), xOver);
          return xSer;
       }
    
       public void SerializeObject(string filename)
       {
          XmlSerializer xSer = CreateOverrider();
    
          GroupDerived myGroup = new GroupDerived();
          myGroup.GroupName = ".NET";
          myGroup.Comment = "My Comment...";
    
          TextWriter writer = new StreamWriter(filename);
    
          xSer.Serialize(writer, myGroup);
          writer.Close();
       }
