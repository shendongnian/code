    class Deck, INotifyPropertyChanged /*custom implementation depends on .NET version, in my case its .NET3.5*/
    {
    private ObservableCollection<Card> _deckCollection = new ObservableCollection<Card>();
    public ObservableCollection<Card> DeckCollection
    {
        get { return _deckCollection; }
        set { _deckCollection = value; 
              OnPropertyChanged(() => DeckCollection); }
    }
    // your Add command
    public ICommand AddItemCommand { get { return new MyCommand(AddToList); } }
    private void AddToList(object parameter)
    {
       DeckCollection.Add(new Card());
    }
    public Deck() { }
    public event PropertyChangedEventHandler PropertyChanged;
	protected void OnPropertyChanged<T>(Expression<Func<T>> expression) 
    {
	   if (PropertyChanged == null) return;
       var body = (MemberExpression)expression.Body;
       if (body != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(body.Member.Name));
	}
