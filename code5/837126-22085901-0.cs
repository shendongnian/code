    /*<Students>
    <Student>
        <Id> 10011</Id>
        <Name>AAA</Name>
        .......
    </Student>
    </Students>
    */
    var xdoc = XDocument.Load(@"C:\students.xml");
    Students students = new Students();
    
    students.students = xdoc.Descendants("Student").Select (x => new Student {
      Id = int.Parse(x.Element("Id").Value),
      Name = x.Element("Name").Value,
      Gender = x.Element("Gender").Value,
      tags = new Tags{
       hobbyTags = new HobbyTags{
        hobbyTags = x.Element("Tags").Element("HobbyTags").Descendants("Tag").Select (t => new Tag{ tag =  t.Value}).ToList()		
       },
       majorTags = new MajorTags{
        majorTags = x.Element("Tags").Element("MajorTags").Descendants("Tag").Select (t => new Tag{ tag =  t.Value}).ToList()		
       },
      }
    
    }).ToList()
;
    public class Tag
    {   
        public string tag {get; set;}
    }
    public class HobbyTags 
    {
       public List<Tag> hobbyTags {get; set;}
    }
    public class MajorTags 
    {
        public List<Tag> majorTags {get; set;}
    }
    public class Tags
    {
        public HobbyTags hobbyTags {get; set;}
        public MajorTags majorTags {get; set;}
    }
    public class Student
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Gender {get; set;}
        public Tags tags {get; set;}
    }
    
    public class Students
    {
        public List<Student> students {get; set;}
    }
