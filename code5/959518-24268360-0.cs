    public class nameService : InameService
    {
    
        private Model model; 
    
        public nameService(Model m) 
        {
           model = m;
        }
    
        public void setMyName(string name)
        {
            model.TestName = name;
        }
    }
    public class Model : INotifyPropertyChanged
    {
    
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            MessageBox.Show(field.ToString());
    
            return true;
        }
    
        // props
        private string testname;
        public  string TestName
        {
            get { return testname; }
            set {
                Model m = new Model();
                m.SetField(ref testname, value, "TestName");
            }
        }    
    }
