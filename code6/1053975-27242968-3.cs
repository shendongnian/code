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
    
                // get all lines from text file
                string[] allLinesFromFile = File.ReadAllLines(pathSource);
    
                // iterate through each line and process it
                foreach(string line in allLinesFromFile)
                {
                	// split each line on ','
                	string[] sections = line.Split(',');
                	student.studentID = sections[0];
                	student.studentName = sections[1];
    
                	// use this loop to add numbers to list of grades
                	for(int i =2; i < sections.Length; i++)
    				{
    					student.grades.Add(sections[i]);
    				}
    
    				// add this student to list
                	myList.Add(student);
    
                	// create new object of student
                	student = new StudentStruct();
                	student.grades = new List<string>();
                }
            }
