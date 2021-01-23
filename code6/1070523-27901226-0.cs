    private Student _selectedStudent;
    public Student SelectedStudent
    {
        get { return _selectedStudent; }
        set
        {
            _selectedStudent = value;
            GetGradesList();
        }
    }
    private void GetGradesList()
    {
        var grades = DatabaseContext.Grades.Where(g => g.Student = SelectedStudent);
        // populate this to grid view like you have done in your current view.
        // And for selected row in the grid you will get values in your textboxes, update those values,
        // and then upgrade that to the database.
    }
    public void UpgradeGrade()
    {
        var grade = DatabaseContext.Grades.FirstOrDefault(g => g == SelectedGrade);
        grade.Value = UpdatedValue;
        DatabaseContext.SaveChanges();
    }
