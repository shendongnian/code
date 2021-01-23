        class Student
        {
            private readonly string name;
            private readonly int age;
            private readonly IList<string> subjects = new List<string>();
            public Student(string name, int age)
            {
                this.name = name;
                this.age = age;
            }
            public void AddSubject(string subject)
            {
                if (age > 18)
                {
                    subjects.Add(subject);
                }
            }
            public IEnumerable<string> Subjects
            {
                get
                {
                    return subjects;
                }
            }
        }
