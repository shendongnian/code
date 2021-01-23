    private List<Student> _students;
    private string _title;
    public Gradebook(double testWeight, double quizWeight, 
              double assignmentWeight,  string[] studentNameArray)
    {
        this._testWeight = testWeight;
        this._quizWeight = quizWeight;
        this._assignmentWeight = assignmentWeight;
        this._students = new List<Student>;
        foreach(var name in studentNameArray)
        {
            _students.Add(new Student(name, 0, this._title);
        }
    }
