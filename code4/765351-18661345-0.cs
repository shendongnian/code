    public static readonly DependencyProperty StudentProperty = DependencyProperty.
        Register("Student", typeof(Student), typeof(MainWindow), new 
        UIPropertyMetadata(100.0));
    public Student Student
    {
        get { return (Student)GetValue(StudentProperty); }
        set { SetValue(StudentProperty, value); }
    }
