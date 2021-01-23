    public ICommand AddTitle { get; private set; }
    public ICommand AddQuestion { get; private set; }
    
    public ViewModel()
    {
    	_standardCollection = new ObservableCollection<Standard>();
    
    	AddTitle = new RelayCommand(OnAddTitle);
    	AddQuestion = new RelayCommand(OnAddQuestion);
    }
    
    void OnAddTitle()
    {
    	_standardCollection.Add(new Standard());
    }
    
    void OnAddQuestion()
    {
    	_standardCollection.Last().Questions.Add(new Question("Some Question"));
    }
