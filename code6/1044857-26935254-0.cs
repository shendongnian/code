    public ObservableCollection<string> Tags {
       get { 
          if(_tags == null){
            //move your code after InitializeComponent() to here
            _tags = new ObservableCollection<string>();
            List<string> tags = Facade.Instance.RetrieveTags();
            foreach(string s in tags) {
                _tags.Add(s);
            }
          }
          return _tags;
       }
    }
