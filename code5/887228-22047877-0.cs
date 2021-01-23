    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }       
    }
    
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Question> Questions
        {
            get { return _Questions; }
            set
            {
                _Questions = value;
                RaisePropertyChanged("Questions");
            }
        }
        private ObservableCollection<Question> _Questions;
        ///read xml file and create object hierarchy
        public MainViewModel()
        {
            Questions = new ObservableCollection<Question>();
            XDocument xml = XDocument.Load("XMLFile1.xml");
            int groupCounter = 0;
            foreach (var questionElement in xml.Descendants("Question"))
            {
                Question question = new Question();
                question.QuestionText = (string)questionElement.Attribute("QuestionText");
                question.Variants = new ObservableCollection<Variant>();
                
                foreach(var variantElement in questionElement.Descendants("Variant")) 
                {
                    Variant variant = new Variant() { VariantText = variantElement.Value, Group = groupCounter.ToString() };                                        
                    question.Variants.Add(variant);
                }
                groupCounter++;
                Questions.Add(question);
            }            
        }
    }
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));            
        }        
    }
    public class Question : ViewModelBase
    {
        public string QuestionText
        {
            get { return _QuestionText; }
            set
            {
                if (_QuestionText != value)
                {
                    _QuestionText = value;
                    RaisePropertyChanged("QuestionText");
                }
            }
        }
        private string _QuestionText;
        public ObservableCollection<Variant> Variants
        {
            get { return _Variants; }
            set
            {
                _Variants = value;
                RaisePropertyChanged("Variants");
            }
        }
        private ObservableCollection<Variant> _Variants;
    }
    public class Variant : ViewModelBase
    {
        public bool IsChecked
        {
            get { return _IsChecked; }
            set
            {
                if (_IsChecked != value)
                {
                    _IsChecked = value;
                    RaisePropertyChanged("IsChecked");
                }
            }
        }
        private bool _IsChecked;
        public string VariantText
        {
            get { return _VariantText; }
            set
            {
                if (_VariantText != value)
                {
                    _VariantText = value;
                    RaisePropertyChanged("VariantText");
                }
            }
        }
        private string _VariantText;
        public string Group
        {
            get { return _Group; }
            set
            {
                if (_Group != value)
                {
                    _Group = value;
                    RaisePropertyChanged("Group");
                }
            }
        }
        private string _Group;
    }    
