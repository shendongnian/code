    public class MainViewModel: ViewModelBase //You should have some ViewModelBase implementing INotifyPropertyChanged, etc
    {
        private Trabajador _model;
        public Trabajador Model
        {
            get { return _model; }
            set
            {
               _model = value;
               NotifyPropertyChange("Model");
            }
        }
    
        public void Registrar()
        {
           DataAccessLayer.Registrar(Model);
        }
     
        public void Clear()
        {
           Model = new Trabajador();
        }
    }
