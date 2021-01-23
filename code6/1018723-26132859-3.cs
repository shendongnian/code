    public class MyItem : FrameworkContentElement, INotifyPropertyChanged
    {
        //INotifyPropertyChanged members:
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        //DependencyProperties
        public static readonly DependencyProperty MyIntProperty = DependencyProperty.Register(
            "MyInt", 
            typeof(int), 
            typeof(MyItem), 
            new PropertyMetadata(0, DependencyPropertyChanged));
        public static readonly DependencyProperty MyStringProperty = DependencyProperty.Register(
            "MyString", 
            typeof(string), 
            typeof(MyItem), 
            new PropertyMetadata("", DependencyPropertyChanged));
        //Callback that invokes the INotifyPropertyChanged.PropertyChangedEventHandler
        private static void DependencyPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            MyItem item = (MyItem)obj;
            item.RaisePropertyChanged(args.Property.Name);
        }
    }
