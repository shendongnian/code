    public class StudentViewModel : ViewModelBase, IDataErrorInfo
    {
        readonly Student _student;
        // Command for registering new student
        private ICommand registerStudent;
        /// <summary>
        /// Initializes a new instance of the StudentViewModel class.
        /// </summary>
        public StudentViewModel(string firstName, string lastName)
        {
            _student = new Student(firstName, lastName);
       }
        public string FirstName
        {
            get { return _student.FirstName; }
            set
            {
                if (value == _student.FirstName)
                    return;
                _student.FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get { return _student.LastName; }
            set
            {
                if (value==_student.LastName)
                    return;
                _student.LastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public ICommand RegisterStudent
        {
            get
            {
                if (registerStudent == null)
                {
                    registerStudent = new CommandBase(i => this.CreateStudent(), null);
                }
                return registerStudent;
            }
        }
    public static IEnumerable<StudentViewModel> GetStudents()
        {
            string databaseName = "Kwega.db3";
            SQLiteConnection connection = new SQLiteConnection("Data Source=" + databaseName + "; Version=3;");
            string students = "SELECT first_name, last_name FROM students";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(students, connection);
            connection.Open();
            adapter.SelectCommand.CommandTimeout = 120;
            DataSet ds = new DataSet();
            adapter.Fill(ds, "students");
            foreach (var student in ds.Tables["students"].DefaultView)
            {
                yield return new StudentViewModel(student[0], student[1]) // or whatever the fields actually are in the table
            }
            connection.Close();
        }
        /// <summary>
        /// Method to create new student and creating a new student table if
        /// it doesnt exist in the database
        /// </summary>
        private void CreateStudent()
        {
            if (_student.IsValid)
            {
                string databaseName = "Kwega.db3";
                var connection = new SQLiteConnection("Data Source=" + databaseName + "; Version=3;");
                connection.Open();
                var createStudentTable =
                    "CREATE TABLE IF NOT EXISTS students (student_id INTEGER PRIMARY KEY, first_name TEXT(255), last_name TEXT(255))";
                var createCommand = new SQLiteCommand(createStudentTable, connection);
                createCommand.ExecuteNonQuery();
                string insert_student = "INSERT INTO students(first_name, last_name) VALUES (" +
                                        "'" + _student.FirstName + "', '" + _student.LastName + "')";
                var insert_CMD = new SQLiteCommand(insert_student, connection);
                insert_CMD.ExecuteNonQuery();
                connection.Close();
            }
            else
            {
                MessageBox.Show("Student details weren't saved", "Invalid student!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        string IDataErrorInfo.Error
        {
            get { return (_student as IDataErrorInfo).Error; }
        }
        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                string error = (_student as IDataErrorInfo)[propertyName];
                return error;
            }
        }
    }
