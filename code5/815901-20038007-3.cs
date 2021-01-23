	private RelayCommand _addStudentCommand;
        public ICommand AddStudentCommand
        {
            get
            {
                return _addStudentCommand
                    ?? (_addStudentCommand = new RelayCommand(() =>
                    {
                        Student student = new Student();
                        student.Name = this.Name;
                        student.Surname = this.Surname;
                        student.Age = this.Age;
                        // here should be the logic of defining the name, surname, 
                        // age and id of the newly created student
                        _StudentList.Add(student);
                    }));
            }
        }
