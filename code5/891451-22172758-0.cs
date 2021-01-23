    public class MainViewModel
    {
        public MainViewModel()
        {
            ServiceReference1.Service1Client client = new erviceReference1.Service1Client();
            Classlist = new ObservableCollection<ClassDO>(client.GetClassList());
        }
    
        public ObservableCollection<ClassDO> ClassList { get; set; }
    }
