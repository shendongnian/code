    public partial class MainWindow : Window
      {
        public MainWindow()
        {
          InitializeComponent();
          this.Loaded += MainWindow_Loaded;
        }
    
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
          Task.Factory.StartNew(() =>
          {
            Console.Write("test");
            Thread.Sleep(1000);
          
            Application.Current.Dispatcher.BeginInvoke(
              DispatcherPriority.Normal, new Action(() => 
              {
                txt.Text = "Testing";
              }));
          });
        }
      }
