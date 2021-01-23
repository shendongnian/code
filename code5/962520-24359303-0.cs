    Class Student
    {
             String Name;
             List<String> Marks;
    }
     private ObservableCollection<Student> _student=new ObservableCollection<Student>();
        public ObservableCollection<Student> student
        {
            get { return _student; }
            set { _student = value; }
        }
