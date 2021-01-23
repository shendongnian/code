    private List<Student> _students;
    private string _title;
    public Gradebook(double testWeight, double quizWeight, 
              double assignmentWeight,  List<Student> students)
    {
        _testWeight = testWeight;
        _quizWeight = quizWeight;
        _assignmentWeight = assignmentWeight;
        _students = students;
        foreach(var student in students)
        {
            student.gradeBookTitle = _title;
        }
    }
