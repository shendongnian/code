        private RelayCommand<Student> _addStudentCommand;
        public ICommand AddStudentCommand
        {
            get
            {
                return _addStudentCommand
                    ?? (_addStudentCommand = new RelayCommand<Student>((student) =>
                        {
                             studentList.Add(student);
                        }));
            }
        }
