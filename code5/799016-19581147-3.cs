    using System;
    using System.Collections.ObjectModel;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Threading;
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private VM _vm = new VM();
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = _vm;
            }
            private void OnLoadClicked(object sender, RoutedEventArgs e)
            {
                Load10Rows();            
            }
            private void Load10Rows()
            {
                Task.Factory.StartNew(() =>
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                                {
                                    _vm.MyList.Add(DateTime.Now.ToString());
                                }), DispatcherPriority.Background);
                            // Just to simulate some work on the background
                            Thread.Sleep(1000);
                        }
                    });
            }
        }
        public class VM
        {
            private ObservableCollection<string> _myList;
            public VM()
            {
                _myList = new ObservableCollection<string>();
            }
            public ObservableCollection<string> MyList
            {
                get { return _myList; }
            }
        }
    }
