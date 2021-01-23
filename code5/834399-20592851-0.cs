     private ObservableCollection<Student> _students;
     public ObservableCollection<Student> Students
      {
        get 
        {
       if(_students==null)
         return utilslib.Getstudents();
       else
        return _students
     }
     set
     {
         _students = value;
         OnPropertyChanged("Students");
     }
  }
