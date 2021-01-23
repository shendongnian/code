    public partial class MainWindow
    {
        public ObservableCollection<int> PrimeNumbers { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            PrimeNumbers = new ObservableCollection<int>();
        }
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PrintPrimes(PrimeNumbers.Add, 1, 10000000, SynchronizationContext.Current);
        }
        private static void PrintPrimes(Action<int> action, int from, int to, 
                                        SynchronizationContext syncContext)
        {
            Task.Run(() =>
            {
                for (var i = from; i <= to; i++)
                {
                    var isPrime = true;
                    var limit = (int) Math.Sqrt(i);
                    for (var j = 2; j <= limit; j++)
                    {
                        if (i%j == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime)
                    {
                        syncContext.Post(state => action((int)state), i);
                        Thread.Sleep(1);
                    }
                }
            });
        }
    }
