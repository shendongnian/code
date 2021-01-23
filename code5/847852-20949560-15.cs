    public class MyViewModel
    {
        public RelayCommand<object> MyCommand { get; set; } 
    }
    public class MyViewModel2 : MyViewModel
    {
        public MyViewModel2()
        {
            MyCommand = new RelayCommand<object>(MyCommandExecute);
        }
        protected virtual void MyCommandExecute(object obj)
        {
            Debug.WriteLine("MyCommand");
        }
    }
