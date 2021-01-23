    class ResulViewModel:ViewModelBase
    {
        readonly Discipline _discipline=new Discipline();
        readonly Test _test=new Test();
        readonly Group _group=new Group();
        readonly Student _student=new Student();
        readonly Result _result=new Result();
        private string _timePass;
        public string Discipline
        {
            get { return _discipline.Discipline1; }
            set { _discipline.Discipline1 = value; RaisePropertyChanged("Discipline"); }
        }
        public string Test
        {
            get { return _test.TestName; }
            set { _test.TestName = value; RaisePropertyChanged("Test");}
        }
        public string Group
        {
            get { return _group.GName; }
            set { _group.GName = value; RaisePropertyChanged("Group");}
        }
        public string Surname
        {
            get { return _student.LastName; }
            set { _student.LastName = value; RaisePropertyChanged("Surname");}
        }
        public string Name
        {
            get { return _student.FirstName; }
            set { _student.FirstName = value; RaisePropertyChanged("Name");}
        }
        public string Point
        {
            get { return _result.Point; }
            set { _result.Point = value; RaisePropertyChanged("Point");}
        }
        public string TimePass
        {
            get { return _timePass; }
            set { _timePass = value; }
        }
        public ObservableCollection<ResulViewModel> Items { get; set; }
        public ResulViewModel(string timePass, string point, string name, string surename, string @group, string test, string discipline)
        {
            TimePass = timePass;
            Point = point;
            Name = name;
            Surname = surename;
            Group = @group;
            Test = test;
            Discipline = discipline;
            Items = new ObservableCollection<ResulViewModel>();
        }
    }
