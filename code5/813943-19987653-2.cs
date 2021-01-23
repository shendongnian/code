    private RelayCommand _addStudentCommand;
        public ICommand AddStudentCommand
        {
            get
            {
                return _addStudentCommand
                    ?? (_addStudentCommand = new RelayCommand(() =>
                        {
                            Student student = new Student(); 
                            studentList.Add(student);
                        }));
            }
        }
