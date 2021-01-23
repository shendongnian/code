     public partial class MainPage : PhoneApplicationPage
    {
		private string defaultText;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            defaultText = "condimentum";
            
            autoCompleteBox1.SelectedItem = defaultText;
        }
        private void autoCompleteBox1_TextChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            string searchText = ((AutoCompleteBox)sender).SearchText;
            if (!String.IsNullOrEmpty(searchText) && !defaultText.Equals(searchText))
            {
                autoCompleteBox1.ItemsSource = SampleWords.AutoCompletions;
                autoCompleteBox1.TextChanged -= autoCompleteBox1_TextChanged;
            }
            
        	
        }
        
    }
