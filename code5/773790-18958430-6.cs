    using System.Collections.ObjectModel;
    using System.Windows;
    namespace Mongoose.Sample
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
            }
            public ObservableCollection<object> PadContents
            {
                get
                {
                    if (padContents == null)
                    {
                        padContents = new ObservableCollection<object>();
                        for (int i = 0; i < 500; i++)
                        {
                            padContents.Add("Pad #" + i);
                        }
                    }
                    return padContents;
                }
            }
            private ObservableCollection<object> padContents;
        }
    }
