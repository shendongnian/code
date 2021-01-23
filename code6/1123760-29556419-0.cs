    class Students
        {
            public string StudentName;
            public int StudSize;
            public bool StudSex;
            public List<Take_Courses> tcourses;
            public Students() { }
            public Students(string name, int size, bool sex, List<Take_Courses> tcourses)
            {
                StudentName = name;
                StudSize = size;
                StudSex = sex;
                this.tcourses = tcourses;
            }
    }
