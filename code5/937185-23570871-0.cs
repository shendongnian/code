    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
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
    
    namespace WpfApplication2
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private ObservableCollection<GridItem> GridItems;    
    
            public MainWindow()
            {
                InitializeComponent();
    
                GridItems = new ObservableCollection<GridItem>();
    
                GridItems.Add(new GridItem { Codigo = "value1", Nombre = "Value2", Selected = false });
                GridItems.Add(new GridItem { Codigo = "value3", Nombre = "Value4", Selected = true });
                GridItems.Add(new GridItem { Codigo = "value5", Nombre = "Value6", Selected = false });
    
                dgServicios.ItemsSource = GridItems;
            }
    
            private void CheckBox_Click(object sender, RoutedEventArgs e)
            {
    
            }
        }
    
    
        public class GridItem : INotifyPropertyChanged
        {
            private bool _Selected;
    
            public bool Selected
            {
                get { return _Selected; }
                set 
                { 
                    _Selected = value;
                    OnPropertyChanged();
                }
            }
    
    
            private string _Codigo;
    
            public string Codigo
            {
                get { return _Codigo; }
                set
                {
                    _Codigo = value;
                    OnPropertyChanged();
                }
            }
            private string _Nombre;
    
            public string Nombre
            {
                get { return _Nombre; }
                set
                {
                    _Nombre = value;
                    OnPropertyChanged();
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    
    }
