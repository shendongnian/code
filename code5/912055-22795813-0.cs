    public partial class MainWindow : Window
    {
        public event EventHandler<EventArgs> UpdateUI; 
        public MainWindow()
        {
            InitializeComponent();
            UpdateUI += sniff;
            PrintFromA();
            PrintFromB();
        }
        private void sniff(object sender, EventArgs e)
        {
            if (lstSample.Items.Contains(45))
            {
                Debugger.Break();
            }
        }
        private void updateUI(int i)
        {
            Dispatcher.Invoke(() =>
            {
                lstSample.Items.Add(i);
            });
            UpdateUI.Invoke(this, new EventArgs());
        }
        private void PrintFromA()
        {
            for (int i = 0; i < 50; i += 2)
            {
                updateUI(i);
            }
        }
        private void PrintFromB()
        {
            for (int i = 0; i < 50; i++)
            {
                updateUI(i);
            }
        } 
    }
