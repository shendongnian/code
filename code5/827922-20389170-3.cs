    using System.Collections.ObjectModel;
    using System.Windows;
    
    namespace WPFSOTETS
    {
    
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            public ObservableCollection<string> Collection
            {
                get
                {
                    return new ObservableCollection<string> {"one","two","three"};
                }
            }
        }
    }
