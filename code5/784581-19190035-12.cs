    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    
    namespace WpfApplication10
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
    
                MyCustomCollection1 = new MyCustomCollection<string>(new[] {"a", "b"});
                MyCustomCollection2 = new MyCustomCollection<string>(new[] {"c", "d"});
            }
    
            public MyCustomCollection<string> MyCustomCollection1 { get; set; }
    
            public MyCustomCollection<string> MyCustomCollection2 { get; set; }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                DataContext = MyCustomCollection1;
            }
    
            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                DataContext = MyCustomCollection2;
            }
        }
    
        public class MyCustomCollection<T> : ObservableCollection<T>
        {
            private T _mySelectedItem;
    
            public MyCustomCollection(IEnumerable<T> collection) : base(collection)
            {
            }
    
            public T MySelectedItem
            {
                get { return _mySelectedItem; }
                set
                {
                    if (Equals(value, _mySelectedItem))return;
                    _mySelectedItem = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("MySelectedItem"));
                }
            }
        }
    }
