    class MyViewModel : INotifyPropertyChanged
    {
        public ICommand SomeCommand { get; private set; }
        public string Text          { get; set; } //INPC omited for brevity
        public int    SelectedIndex { get; set; } //INPC omited for brevity
        public MyViewModel()
        {
            SomeCommand = new RelayCommand(DoSomeCommand, CanDoSomeCommand);
        }
        private void DoSomeCommand()
        {
            //Blah
        }
        private bool CanDoSomeCommand()
        {
            return !String.IsNullOrWhiteSpace(this.Text) && this.SelectedIndex > -1;
        }
    }
