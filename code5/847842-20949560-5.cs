    public class MyViewModel
    {
        public MyViewModel()
        {
            MyCommand = new RelayCommand<object>(MyCommandExecute);
        }
        public RelayCommand<object> MyCommand { get; set; } 
        protected virtual void MyCommandExecute(object obj)
        {
            Debug.WriteLine("Main");
        }
    }
    public class MyViewModel2 : MyViewModel
    {
        public MyViewModel2()
        {
            MyCommand2 = new RelayCommand<object>(MyCommand2Execute);
        }
        public RelayCommand<object> MyCommand2 { get; set; } 
        protected override void MyCommandExecute(object obj)
        {
            Debug.WriteLine("Derived");
        }
        protected virtual void MyCommand2Execute(object obj)
        {
            Debug.WriteLine("New");
        }
    }
