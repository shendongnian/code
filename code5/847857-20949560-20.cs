    public class MyViewModel : INotifyPropertyChanged
    {
        private MyViewModel currentViewModel;
        public RelayCommand<object> MyCommand { get; set; } 
        public MyViewModel()
        {
            MyCommand = new RelayCommand<object>(MyCommandExecute);
        }
        public MyViewModel CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                if (value != currentViewModel)
                {
                    currentViewModel = value;
                    OnPropertyChanged();
                }
            }
        }
        protected virtual void MyCommandExecute(object obj)
        {
            switch (int.Parse(obj.ToString()))
            {
                case 1:
                    CurrentViewModel = new MyViewModel1();
                    break;
                case 2:
                    CurrentViewModel = new MyViewModel2();
                    break;
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class MyViewModel1 : MyViewModel
    {
        public RelayCommand<object> MyCommand1 { get; set; }
        public MyViewModel1()
        {
            MyCommand1 = new RelayCommand<object>(MyCommand1Execute);
        }
        private void MyCommand1Execute(object obj)
        {
            Debug.WriteLine("MyCommand1");
        }
    }
    public class MyViewModel2 : MyViewModel
    {
        public RelayCommand<object> MyCommand2 { get; set; }
        public MyViewModel2()
        {
            MyCommand2 = new RelayCommand<object>(MyCommand2Execute);
        }
        private void MyCommand2Execute(object obj)
        {
            Debug.WriteLine("MyCommand2");
        }
    }
