     public class Students
    {
        public string StudentName { get; set; }
        public int GradePoint { get; set; }
        public int StudentId { get; set; }
        public List<Students> GetStudentRecords()
        {
            List<Students> stulist = new List<Students>();
            stulist.Add(new Students { StudentId = 1, StudentName = " Joseph ", GradePoint = 800 });
            stulist.Add(new Students { StudentId = 2, StudentName = "Alex", GradePoint = 458 });
            stulist.Add(new Students { StudentId = 3, StudentName = "Harris", GradePoint = 900 });
            stulist.Add(new Students { StudentId = 4, StudentName = "Taylor", GradePoint = 900 });
            stulist.Add(new Students { StudentId = 5, StudentName = "Smith", GradePoint = 458 });
            stulist.Add(new Students { StudentId = 6, StudentName = "Natasa", GradePoint = 700 });
            stulist.Add(new Students { StudentId = 7, StudentName = "David", GradePoint = 750 });
            stulist.Add(new Students { StudentId = 8, StudentName = "Harry", GradePoint = 700 });
            stulist.Add(new Students { StudentId = 9, StudentName = "Nicolash", GradePoint = 597 });
            stulist.Add(new Students { StudentId = 10, StudentName = "Jenny", GradePoint = 750 });
            return stulist;
        }
    }
