    class Service
    {
        private ObservableCollection<Student> studentsList;
        public StudentEntities StudentEntities { get; set; }
        public ObservableCollection<Student> Students
        {
            get
            {
                if (studentsList == null && StudentEntities != null)
                {
                    StudentEntities.Set<Student>().Load();
                    studentsList = StudentEntities.Set<Student>().Local;
                }
                return studentsList;
            }
        }
        
        public static IEnumerable<Student> GetAllStudents()
        {
            // Code here
        }   
    }
