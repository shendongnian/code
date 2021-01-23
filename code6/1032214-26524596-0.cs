    class MainWindowViewModel
    {
        MainWindowViewModel
        {
         ChildViewModel  = new TabControl1ViewModel(this);
        }
        public TabControl1ViewModel ChildViewModel {get; private set;}
    }
    
    class TabControl1ViewModel
    {
        public MainWindowViewModel ParentViewModel {get; private set;}
        TabControl1ViewModel(MainWindowViewModel mainWindowViewModel)
        {
            ParentViewModel  = mainWindowViewModel;
        }
    }
