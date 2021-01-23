    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls.Primitives;
    
    namespace WpfApplication1
    {
        public partial class MainWindow:INotifyPropertyChanged
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private List<MyItem> _collection = new List<MyItem>();
            public List<MyItem> Collection 
            { 
                get { return _collection; }
                set { _collection = value; InvokePropertyChanged(new PropertyChangedEventArgs("Collection")); }
            }
    
            private Thickness _offset1;
            public Thickness Offset1
            {
                get { return _offset1; }
                set { _offset1 = value; InvokePropertyChanged(new PropertyChangedEventArgs("Offset1")); }
            }
    
            private Thickness _offset2;
            public Thickness Offset2
            {
                get { return _offset2; }
                set { _offset2 = value; InvokePropertyChanged(new PropertyChangedEventArgs("Offset2")); }
            }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                Collection.Add(new MyItem("item1", "10"));
                Collection.Add(new MyItem("item2", "200"));
                Collection.Add(new MyItem("item3", "600000"));
                Collection.Add(new MyItem("item4", "1"));
            }
    
            private void ScrollBar1_Scroll(object sender, ScrollEventArgs e)
            {
                //imitate scrolling here
                double leftToRight = Offset1.Left;
                if (e.ScrollEventType == ScrollEventType.SmallIncrement)
                    leftToRight += 5;
                if (e.ScrollEventType == ScrollEventType.SmallDecrement)
                    leftToRight -= 5;
                Offset1 = new Thickness(leftToRight, 0, 0, 0);
            }
    
            private void ScrollBar2_Scroll(object sender, ScrollEventArgs e)
            {
                //imitate scrolling here
                double leftToRight = Offset2.Left;
                if (e.ScrollEventType == ScrollEventType.SmallIncrement)
                    leftToRight += 5;
                if (e.ScrollEventType == ScrollEventType.SmallDecrement)
                    leftToRight -= 5;
                Offset2 = new Thickness(leftToRight, 0, 0, 0);
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void InvokePropertyChanged(PropertyChangedEventArgs e)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, e);
            }
            
        }
    
        public class MyItem
        {
            public string name { get; set; }
            public string price { get; set; }
    
            public MyItem(string  n, string p)
            {
                name = n;
                price = p;
            }
        }
    }
