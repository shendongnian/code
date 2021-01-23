    using System.ComponentModel;
    //using Microsoft.Win32;
    
    
    namespace UncaughtExceptionHandler
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                //AppDomain currentDomain = AppDomain.CurrentDomain;
                //currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
                InitializeComponent();
            }
            private void ButtonA_Click(object sender, RoutedEventArgs e)
            {
                throw new Exception("WTFA!?!?");
            }
            private void ButtonB_Click(object sender, RoutedEventArgs e)
            {
                System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
                ofd.FileOk += MyCanelEventHandler;
                //ofd.FileOk += (s, ce) =>
                //{
                //    //MessageBox.Show("Throwikng Exception WTF2!?!?");
                //    throw new Exception("WTF2!?!?");
                //};
                ofd.ShowDialog();
            }
            static void MyCanelEventHandler(Object sender, CancelEventArgs e)
            {
                MessageBox.Show("MyCanelEventHandler");
                throw new Exception("WTFCEH!?!?");
            }
        }
    }
