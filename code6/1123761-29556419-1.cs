    class Take_Courses
        {
            public string classname;
            public List<Arr_Courses> arr_Course;
            public Take_Courses() { }
           public Take_Courses(string classname, List<Arr_Courses> arr_courses)
            {
                this.classname = classname;
                arr_Course = arr_courses;
            }
        }
    
    class Arr_Courses
        {
            public string cosname;
            public string cosdesc;
            public float cospoint;
            public Arr_Courses() { }
            public Arr_Courses(string name, string description, float point)
            {
                cosname = name;
                cosdesc = description;
                cospoint = point;
            }
        }
