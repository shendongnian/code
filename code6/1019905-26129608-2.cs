        using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace delete
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            public MainWindow()
            {
                InitializeComponent();
                Setup();
                this.DataContext = this;
            }
    
            ObservableCollection<Thang> _items;
            public ObservableCollection<Thang> items
            {
                get { return _items; }
    
                set
                {
                    _items = value;
                    OnPropertyChanged("items");
                }
            }
    
            private Thang _item;
            public Thang item
            {
                get { return _item; }
                set
                {
                    _item = value;
                    OnPropertyChanged("item");
                }
            }
    
            public void Setup()
            {
                items = new ObservableCollection<Thang>();
                items.Add(new Thang("1", "One"));
                items.Add(new Thang("2", "Two"));
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected void OnPropertyChanged(string name)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
        }
    
        public class Thang
        {
            public Thang(string id, string name)
            {
                Name = name;
                ID = id;
            }
    
            public string Name { get; set; }
            public string ID { get; set; }
        }
    }
