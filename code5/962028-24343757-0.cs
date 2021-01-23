        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
    ConcurrentStack<int> cs = new ConcurrentStack<int>();
    
            public static double YourFunction(int SomeNumber)
            {
                // computation of result
                return result;
            }
        
            private void start_Click(object sender, RoutedEventArgs e)
            {
                textBlock1.Text = "";
                label1.Content = "Milliseconds: ";
        
                var watch = Stopwatch.StartNew();
                List<Task> tasks = new List<Task>();
                for (int i = 2; i < 20; i++)
                {
                    int j = i;
                    var t = Task.Factory.StartNew(() =>
                    {
                        int result = YourFunctiopn(j);
                        this.Dispatcher.BeginInvoke(new Action(() =>
                             cs.Add(result ))
                        , null);
                    });
                    tasks.Add(t);
                }
        
                Task.Factory.ContinueWhenAll(tasks.ToArray(),
                      result =>
                      {
                          var time = watch.ElapsedMilliseconds;
                          this.Dispatcher.BeginInvoke(new Action(() =>
                              label1.Content += time.ToString()));
                      });
        
            }
        }
