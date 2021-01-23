    public class MyClass : NotifyPropertyChanged
    {
        public string Title { get { return _title; } set { SetProperty(ref _title, value); } }
        string _title;
    }
