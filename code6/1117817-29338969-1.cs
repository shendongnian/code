    using System.Xml;
    using System.Xml.Serialization;
 
     public class Student
     { 
 	    [XmlElement("NAME")]
 	    public string Name;
        [XmlElement("AGE")]
 	    public int Age;
        
     }
     using System.Collections.Generic;
     using System.Xml;
     using System.Xml.Serialization;
     using System.IO;
    [XmlRoot("STUDENT_INFO")]
    public class StudentContainer()
    {
      [XmlArrayItem("STUDENT")]
      public List<Student> Stu = new List<Student>();
      
       public void Save(string path)
 	    {
 		   var serializer = new XmlSerializer(typeof(StudentContainer));
 		   using(var stream = new FileStream(path, FileMode.Create))
 		   {
 			   serializer.Serialize(stream, this);
 		   }
    }
 
 	public static StudentContainer Load(string path)
 	{
 		var serializer = new XmlSerializer(typeof(StudentContainer));
 		using(var stream = new FileStream(path, FileMode.Open))
 		{
 			return serializer.Deserialize(stream) as StudentContainer;
 		}
 	}
 
         //Loads the xml directly from the given string. Useful in combination with www.text.
         public static StudentContainer LoadFromText(string text) 
 	{
 		var serializer = new XmlSerializer(typeof(StudentContainer));
 		return serializer.Deserialize(new StringReader(text)) as StudentContainer;
 	   }
    }
