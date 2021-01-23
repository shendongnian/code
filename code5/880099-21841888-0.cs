    public class TestWindow
    {
        // A collection of SubjectNames to bind with the first listview
        private ObservableCollection<TestsSubjectsNames> _subjectNames;
        public ObservableCollection<TestsSubjectsNames> SubjectNames
        {
            get { return _subjectNames; }
            set
            {
               _subjectNames = value;
               NotifyPropertyChanged("SubjectNames");
            }
        }
        // A collection of Test for the second listview
        private ObservableCollection<Tests> _testNames;
        public ObservableCollection<Tests> TestNames
        {
            get { return _testNames; }
            set
            {
               _testNames= value;
               NotifyPropertyChanged("TestNames");
            }
        }
        // The current selected TestsSubjectsNames in first listview
        private TestsSubjectsNames _selectedSubjectNames;
        public TestsSubjectsNames SelectedSubjectNames
        {
            get { return _selectedSubjectNames; }
            set
            {
               _selectedSubjectNames= value;
               // Call this function in the setter
               // Will change the Collection binded to the second listview
               OnSelectedSubjectNameChanged(value);
               NotifyPropertyChanged("SelectedSubjectNames");
            }
        }
        public TestWindow()
        {
            // Initialization and set datacontext
            InitializeComponent();
            DataContext = this;
            // Initialize the suject name list for the first listview
            SubjectNames = GetAllSubjectNames();
            // Second listview empty until we select something in the first list
            // so initialize it empty
            TestNames = new ObservableCollection<Tests>();
        }
        // Will be called everyTime the selectedItem in the first listview changes
        private void OnSelectedSubjectNameChanged(TestsSubjectsNames subjectName)
        {
              // Get The list of Tests with the selected subjectName ID
              // and put the result in the observable collection
              TestNames = new ObservableCollection<Tests>(GetAllTestsNames(subjectName.ID))
        }
    }
