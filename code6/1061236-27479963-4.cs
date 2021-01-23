    private ObservebleCollection<String> _parameters = new ObservebleCollection<String>();
   
    public ObservebleCollection<String> Parameters 
    {
        get 
        { 
            return _parameters;
        }
        private set 
        {
            _parameters=value;
            PropertyChanged("Parameters");
        }
        public void CopyParameters()
        {
            var newParameters=currentRobot.GetParametersProvider()
                                          .GetParameters()
                                          .Select(p=>p.PropertyName);
            Parameters=new ObservableCollection<string>(newParameters);
        }
