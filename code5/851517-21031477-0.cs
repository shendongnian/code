    public IDictionary<string, Student> StudentDictionary { get; set; }
    public Gradebook(double testWeight, double quizWeight, 
                     double assignmentWeight, string[] studentNameArray) {
        StudentDictionary = new Dictionary<string, Student>();
        foreach (var name in studentNameArray) {
            StudentDictionary.Add(name, new Student(name, <age_here>, this.Title));
        }
    }
