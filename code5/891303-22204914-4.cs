                private MyCommand selectionChangedCommand;
        
                public MyCommand SelectionChangedCommand
                {
                    get 
                    {
                        if (selectionChangedCommand == null)
                        {
                            selectionChangedCommand = new MyCommand(SelectionChanged);
                        }
                        return selectionChangedCommand;
                    }
                    set { selectionChangedCommand = value; }
                }
                public void SelectionChanged(object value)
                {
                    SelectedItem = new ObservableCollection<Model>((value as IEnumerable).OfType<Model>());
                }
               
        
                private ObservableCollection<Model> selectedItem;
        
                public ObservableCollection<Model> SelectedItem
                {
                    get { return selectedItem; }
                    set { selectedItem = value; RaisePropertyChanged("SelectedItem"); }
                }
        
                private ObservableCollection<Model> mycoll;
        
        	public ObservableCollection<Model> MyCollection
        	{
        		get { return mycoll;}
        		set { mycoll = value;}
        	}
                public ViewModel()
                {
                    SelectedItem = new ObservableCollection<Model>();
                    SelectedItem.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(SelectedItem_CollectionChanged);
                    MyCollection = new ObservableCollection<Model>();
                    MyCollection.Add(new Model { FirstName = "aaaaa", SecondName = "bbbbb", Company = "ccccccc" });
                    MyCollection.Add(new Model { FirstName = "ddddd", SecondName = "bbbbb", Company = "eeeeeee" });
                    MyCollection.Add(new Model { FirstName = "fffff", SecondName = "gggggg", Company = "ccccccc" });
        
                }
        
                void SelectedItem_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
                {
                    //this.SelectedItem =new ObservableCollection<Model>((sender as ObservableCollection<Model>).Distinct());
                }
                public event PropertyChangedEventHandler PropertyChanged;
                private void RaisePropertyChanged(string name)
                {
                    if(PropertyChanged!= null)
                    {
                        this.PropertyChanged(this,new PropertyChangedEventArgs(name));
                    }
                }
            }
            public class MyCommand : ICommand
            {
                private Action<object> _execute;
        
                private Predicate<object> _canexecute;
        
                public MyCommand(Action<object> execute, Predicate<object> canexecute)
                {
                    _execute = execute;
                    _canexecute = canexecute;
                }
        
                public MyCommand(Action<object> execute)
                    : this(execute, null)
                {
                    _execute = execute;
                }
        
                #region ICommand Members
        
                public bool CanExecute(object parameter)
                {
                    if (parameter == null)
                        return true;
                    if (_canexecute != null)
                    {
                        return _canexecute(parameter);
                    }
                    else
                    {
                        return true;
                    }
        
                }
        
                public event EventHandler CanExecuteChanged
                {
                    add { CommandManager.RequerySuggested += value; }
                    remove { CommandManager.RequerySuggested -= value; }
                }
        
        
                public void Execute(object parameter)
                {
                    _execute(parameter);
                }
        
                #endregion
            }
