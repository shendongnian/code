    public class MyClass : NotifyPropertyChanged
    {
        public string Text { get => _text; set => SetProperty(ref _text, value); }
        string _text;
    }
