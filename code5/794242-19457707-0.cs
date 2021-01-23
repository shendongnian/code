    ICommand _Print_Line;
    
    ICommand _Add_Line;
    
    
    public ViewModel()
    {
        _Print_Line = new SimpleDelegateCommand((x) => MessageBox.Show(x.ToString()));
    
        _Add_Line = new SimpleDelegateCommand((x) =>
         View_ = new ObservableCollection<View>() /////////Error HERE
        {
            new View(){View_String = x.ToString()}
        }
        );
    
        View_ = new ObservableCollection<View>()
        {
            new View(){View_String = "Setting 1"},
            new View(){View_String = "Setting 2"}
        };
    }
