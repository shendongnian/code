    public class MyViewModelOrCodeBehindClass
    {
        public ObservableCollection<FileSetting> FileSettings 
        {
            get; 
            private set; 
        }
    
        public MyViewModel()
        {
            FileSettings = new ObservableCollection<FileSetting>();
            // If you're using codebehind rather than having something 
            // else set this class as the datacontext:
            DataContext = this;
        }
    }
