    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
        private void calculate_Click(object sender, RoutedEventArgs e)
        {
    
            int val, val1, val2;
    
        
            if (!int.TryParse(first.Text, out val))
            {
                val=0; // Invalid or blank input get's a zero (or you could show an error message)
            }
    
            if (!int.TryParse(second.Text, out val1))
            {
                val1=0; // Invalid or blank input get's a zero (or you could show an error message)
            }
    
            if (!int.TryParse(third.Text, out val2))
            {
                val2=0; // Invalid or blank input get's a zero (or you could show an error message)
            }
    
            if ((bool)oneValue.IsChecked)
                showTotal(val);
            else if ((bool)twoValues.IsChecked)
                showTotal(val, val1);
            else if ((bool)threeValues.IsChecked)
                showTotal(val, val1, val2);
        }
    
            private void showTotal(int val, int val1, int val2)
        {
            int total = val + val1 + val2;
            result.Text = total.ToString();
        }
    
        private void showTotal(int val, int val1)
        {
            int total = val + val1;
            result.Text = total.ToString();
        }
    
        private void showTotal(int val)
        {
            result.Text = val.ToString();
        }
    
        private void quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
