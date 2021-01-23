    public class ViewModel
    {
        public ViewModel()
        {
            this.ButtonClick = new RelayCommand(_ => this.DoSomething());
        }
    
        public ICommand ButtonClick { get; set; }
        public void DoSomething()
        {
            // Something...
        }
    }
