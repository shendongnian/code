    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media;
    namespace WpfApplication25
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                // This is just some sample data:
                UserCollection = Fonts.GetTypefaces(@"C:\Windows\Fonts").ToList();
                DataContext = this;
            }
            // Property to gain access to the sample data:
            public List<Typeface> UserCollection { get; private set; }
        }
    }
