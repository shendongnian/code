    public class PersonRequest : RequestBase
        {
            public class Field
            {
                public int fieldId { get; set; }
                public string fieldValue { get; set; }
            }
    
            public class Group
            {
                public int groupId { get; set; }
            }
    
            public class Person
            {
                public string name { get; set; }
                public string age { get; set; }
                public string dateOfBirth { get; set; }
                public List<Group> groups { get; set; }
            }
    
            public int id { get; set; }
            public List<Field> dynamic { get; set; }
            public Person person { get; set; }
        }
