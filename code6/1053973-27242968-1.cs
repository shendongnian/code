    class Program
        {
            static string pathSource = @"C:\schoolfiles\StudentGrades.txt";
    
            struct StudentStruct
            {
                public string studentID;
                public string studentName;
                public List<string> grades;
            }
    
            static void Main(string[] args)
            {
                StudentStruct student = new StudentStruct();
                List<StudentStruct> myList = new List<StudentStruct>();
                student.grades = new List<string>();
    
                string[] allLinesFromFile = File.ReadAllLines(pathSource);
                foreach(string line in allLinesFromFile)
                {
                	string[] sections = line.Split(',');
                	student.studentID = sections[0];
                	student.studentName = sections[1];
    
                	student.grades.Add(sections[2]);
                	student.grades.Add(sections[3]);
                	student.grades.Add(sections[4]);
                	student.grades.Add(sections[5]);
                	student.grades.Add(sections[6]);
                	student.grades.Add(sections[7]);
                	student.grades.Add(sections[8]);
    
                	myList.Add(student);
                	student = new StudentStruct();
                }
            }
