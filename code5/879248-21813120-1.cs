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
            public bool IsMale
            {
                get { return _type == 0; }
                set { _type = value ? 0 : 1; }
            }
            public bool IsFemale
            {
                get { return _type == 1; }
                set { _type = value ? 1 : 0; }
            }
        }  
