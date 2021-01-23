    using System.Collections.ObjectModel;
    using System.Windows;
    
    namespace WpfApplication3
    {
        /// <summary>
        ///     Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow() {
                InitializeComponent();
            }
        }
    
        internal class MyObject
        {
            public string Category { get; set; }
            public int Value { get; set; }
        }
    
        internal class MyObjectCollection : ObservableCollection<MyObject>
        {
        }
    }
