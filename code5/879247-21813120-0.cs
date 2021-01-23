        class Person
        {
            public string Name { get; private set; }
            public Gender Gender { get; private set; }
            public Person(string name, Gender gender)
            {
                Name = name;
                Gender = gender;
            }
        }
        struct Gender
        {
            private int _type;
            public Gender(int type)
            {
                _type = type;
            } 
       
            public bool IsMale
            {
                get { return _type == 0; }
            }
            public bool IsFemale
            {
                get { return _type == 1; }
            }
        }  
