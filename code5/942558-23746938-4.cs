    // ViewModel
    public class MyViewModel : INotifyPropertyChanged
    {
        public string Text { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    // View
    public void Loaded()
    {
        var myBox = new TextBox();
        var myAni = new Storyboard();
        var MyVvm = new MyViewModel();
        // sensible approach
        myBox.TextChanged += (s, e) => myAni.Begin();
        // forced approach
        MyVvm.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName.Equals("Text"))
                myAni.Begin();
        };
    }
