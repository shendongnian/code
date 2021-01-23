    class Gradebook
    {
        public Gradebook(double testWeight, double quizWeight, double assignmentWeight, string[] studentNameArray)
        {
            this.TestWeight = testWeight;
            this.QuizWeight = quizWeight;
            this.AssingmentWeight = assignmentWeight;
            this.Students = new List<Student>();
            foreach(var name in studentNameArray)
                Students.Add(new Student(
                    studentName: name, 
                    age: 0,
                    gradeBookTitle: ""
                    )
                );
        }
    
        public double TestWeight { get; set; }
    
        public double QuizWeight { get; set; }
    
        public double AssingmentWeight { get; set; }
    
        public IList<Student> Students { get; set; }
    }
    
    class Student
    {
        public Student(string studentName, int age, string gradeBookTitle)
        {
    
        }
    }
