        sealed class Student
        {
            public string Name
            {
                get;
                private set;
            }
            Student()
            {
            }
            public static implicit operator Student(string name)
            {
                return new Student
                {
                    Name = name
                };
            }
        }
