    void Main()
    {
        var TeacherAccesses = new List<Teacher>() {
            new Teacher() { ID = 1, Name = "Teacher-A", TeacherAttr = new Attr() { SchoolEndYear = 2012 } },
            new Teacher() { ID = 1, Name = "Teacher-A", TeacherAttr = new Attr() { SchoolEndYear = 2013 } },
            new Teacher() { ID = 1, Name = "Teacher-A", TeacherAttr = new Attr() { SchoolEndYear = 2014 } },
            new Teacher() { ID = 2, Name = "Teacher-B", TeacherAttr = new Attr() { SchoolEndYear = 2012 } },
            new Teacher() { ID = 2, Name = "Teacher-B", TeacherAttr = new Attr() { SchoolEndYear = 2013 } },
            new Teacher() { ID = 3, Name = "Teacher-C", TeacherAttr = new Attr() { SchoolEndYear = 2012 } }
        };
        //TeacherAccesses.Dump();
        var latest =
            from teacher in TeacherAccesses
            where teacher.TeacherAttr.SchoolEndYear == TeacherAccesses.Where(x => x.ID == teacher.ID).Max(x => x.TeacherAttr.SchoolEndYear)
            select new {
                Name = teacher.Name,
                Year = teacher.TeacherAttr.SchoolEndYear
            };
        latest.Dump();
    }
    // Define other methods and classes here
    public class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Attr TeacherAttr { get; set; }
    }
    public class Attr
    {
        public int SchoolEndYear { get; set; }
    }
