    public class MainVM
    {
        public MainVM() {
            _mItems.Add(new ClassA() { HeadText = "Dyn1" });
            _mItems.Add(new ClassA() { HeadText = "Dyn2" });
            _mItems.Add(new ClassA() { HeadText = "Dyn3" });
        }
        private ObservableCollection<ClassA> _mItems = new ObservableCollection<ClassA>();
        public ObservableCollection<ClassA> MItems{
            get { return _mItems; }
        }
    }
    public class ClassA
    {
        public ClassA() { }
        private string _text = "";
        public String HeadText {
            get { return _text; }
            set { _text = value; }
        }
    }
