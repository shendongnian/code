        class StudentContext
        {
            public List<Student> Studentslist { get; set; }
    
            public void AddStudent(Student student)
            {
                if (null == Studentslist)
                {
                    Studentslist = new List<Student>();
                }
                Studentslist.Add(student);
            }
    
            public void AddFriend(Student student,Student friendStudent)
            {
                Studentslist.Where(x => x.StudentId == student.StudentId).FirstOrDefault().Friend = friendStudent;
            }
        }
    
        class Student
        {
            public int StudentId { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public int Marks { get; set; }
            public Student Friend { get; set; }
        }
      public class Test
      {
         public static void Main()
         {
                Student student1 = new Student();
                student1.StudentId = 1;
                student1.Name = "A";
                student1.Marks = 100;
    
                Student student2 = new Student();
                student2.StudentId = 2;
                student2.Name = "AB";
                student2.Marks = 10;
    
                StudentContext studentContext = new StudentContext();
                studentContext.AddStudent(student1);
                studentContext.AddStudent(student2);
                studentContext.AddFriend(student1, student2);
    
                student1.Marks = 50;
                student2.Marks = 77;
         }
     }
