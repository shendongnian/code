      public class Person
        {
            public Person()
            {
            }
        
            private string name = "";
            public string Name
            {
                get { return name; }
                set { if (name != value) name = value; }
            }
        
            private string surname = "";
            public string Surname
            {
                get { return surname; }
                set { if (surname != value) surname = value; }
            }
        
            private Children sourceList;
            public Children SourceList
            {
                get { 
    if(sourceList == null)
      return new Children();
    else
      return sourceList; 
    }
                set { if (sourceList != value) 
                     sourceList = value.ForEach(person => { person.Surname = surname; }); 
                    }
            }
        }
        
            [TypeConverter(typeof(TypeConverter))]
            public class Children : List<Person>
            {
            
            }
