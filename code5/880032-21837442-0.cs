     class MovingItemViewModel : INotifyPropertyChanged 
    {
        public Thickness Margin { get; set; }
        public String Data { get; set; }
        public ICommand MoveRightCommand { get; set; }
        public MovingItemViewModel() {
            Margin = new Thickness(0, 0, 0, 0);
            Data = "Hello!";
            MoveRightCommand = new RelayCommand(param => MoveRight());
        }
        public void MoveRight() {
            Console.WriteLine("Right Key is pressed!");
            double offset = Margin.Right - 10;
            Margin = new Thickness(0, 0, offset, 0);
            OnPropertyChanged("Margin");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged( [CallerMemberName] string propertyName = null ) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
