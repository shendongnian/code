    public class Students
        {
            public Students(Course c, int start, int end)
            {
                MyCourse = c;
                idStart = start;
                idEnd = end;
            }
            //        public string course { get; set; }
            public int idStart { get; set; }
            public int idEnd { get; set; }
            public Course MyCourse { get; set; }
        }
    
        public enum Course
        {
            CSharp,
            Java
        }
    
    
        public class MiscTests
        {
            /*
       C#Course student Ids [1, 25];
       JavaCourse students [50, 60];
       C#Course student Ids[20, 36];
       JavaCourse students [40, 55];
       C#Course student Ids[70, 80];
    
       ///////////////////Result///////////////////////////
       C#Course student Ids[1, 36];
       JavaCourse student Ids[40, 60];
       C#Course student Ids[70, 80];
           */
            private List<Students> students;
            private List<Students> result;
            public MiscTests()
            {
                students = new List<Students>
                {
                    new Students(Course.CSharp, 1, 25),
                    new Students(Course.Java, 50, 60),
                    new Students(Course.CSharp, 20, 36),
                    new Students(Course.Java, 40, 55),
                    new Students(Course.CSharp, 70, 80),
                };
    
                result = new List<Students>();
            }
    
            public void Run()
            {
                students = students.OrderBy(s => s.idEnd).ThenBy(s=>s.MyCourse).ToList();
                foreach (var s in students)
                {
                    var lastOne = result.LastOrDefault(r=>r.MyCourse == s.MyCourse);
                    if (lastOne == null)
                    {
                        result.Add(s);
                    }
                    else
                    {
                        var last = result.Last();
                        if (lastOne.MyCourse == last.MyCourse)
                        {
                            lastOne.idEnd = Math.Max(s.idEnd, lastOne.idEnd);
                            lastOne.idStart = Math.Min(s.idStart, lastOne.idStart);
                        }
                        else
                        {
                            result.Add(s);
                        }
                    }
                }
            }
        }
