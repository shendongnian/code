    using System;
    using System.Collections.Generic;
    
    namespace ReadXMLData
    {
        [Serializable]
        [System.Xml.Serialization.XmlRoot("People")]
        public class People : List<Person>
        {
        }
    
        [Serializable]
        public class Person
        {
            public Name Name { get; set; }
    
            public Person()
            {
                this.Name = new Name();
            }
        }
    
        [Serializable]
        public class Name
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string FullName
            {
                get
                {
                    return this.FirstName + " " + this.LastName;
                }
            }
    
            public Name()
            {
                this.FirstName = string.Empty;
                this.LastName = string.Empty;
            }
        }
    }
