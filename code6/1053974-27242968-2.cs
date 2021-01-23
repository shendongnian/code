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
    
                	for(int i =2; i < sections.Length; i++)
    				{
    					student.grades.Add(sections[i]);
    				}
    
                	myList.Add(student);
                	student = new StudentStruct();
                }
            }
