    public partial class MainWindow : Window
    {
        List<string> stringCollection;
        public MainWindow()
        {
            InitializeComponent();
            stringCollection = new List<string>
            {
                "abc","ayr","bef","bcs","caa","lmn"
            };
            txtAuto.TextChanged += txtAuto_TextChanged;
        }
        void txtAuto_TextChanged(object sender, TextChangedEventArgs e)
        {
            string typedString = txtAuto.Text;
            List<string> autoList = new List<string>();
            autoList.Clear();
            foreach (string item in stringCollection)
            {
                if (!string.IsNullOrEmpty(txtAuto.Text))
                {
                    if (item.Contains(typedString))
                    {
                        autoList.Add(item);
                    }
                }
            }
            if (autoList.Count > 0)
            {
                lblSuggestion.ItemsSource = autoList;
                lblSuggestion.Visibility = Visibility.Visible;
            }
            else if (txtAuto.Text.Equals(""))
            {
                lblSuggestion.Visibility = Visibility.Collapsed;
                lblSuggestion.ItemsSource = null;
            }
            else
            {
                lblSuggestion.Visibility = Visibility.Collapsed;
                lblSuggestion.ItemsSource = null;
            }
        }
        void lblSuggestion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lblSuggestion.ItemsSource != null)
            {
                lblSuggestion.KeyDown += lblSuggestion_KeyDown;               
            }
        }
        private void txtAuto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                lblSuggestion.Focus();
            }
        }
        private void lblSuggestion_KeyDown(object sender, KeyEventArgs e)
        {
            if (ReferenceEquals(sender, lblSuggestion))
            {
                if (e.Key == Key.Enter)
                {
                    txtAuto.Text = lblSuggestion.SelectedItem.ToString();
                    lblSuggestion.Visibility = Visibility.Collapsed;
                }
          
                if (e.Key == Key.Down)
                {
                    e.Handled = true;
                    lblSuggestion.Items.MoveCurrentToNext();
                }
                if (e.Key == Key.Up)
                {
                    e.Handled = true;
                    lblSuggestion.Items.MoveCurrentToPrevious();
                }
            }
        }
    }
