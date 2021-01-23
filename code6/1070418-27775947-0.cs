    private RelayCommand _insertDataCommand;
        public RelayCommand InsertDataCommand
        {
            get
            {
                return _insertDataCommand
                       ?? (_insertDataCommand = new RelayCommand(
                           () =>
                           {
                               Students.Add(new Student
                               {
                                   StudentRollNo = this.StudentRollNo,
                                   StudentName = this.StudentName,
                                   StudentEmail = this.StudentEmail,
                                   StudentContactNo = this.StudentContactNo
                               });
                               StudentRollNo = String.Empty;
                               StudentName = String.Empty;
                               StudentEmail = String.Empty;
                               StudentContactNo = String.Empty;
                           }));
            }
        }
