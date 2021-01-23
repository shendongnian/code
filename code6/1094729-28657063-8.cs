    // This is a Page (Window in case of using WPF).
    public class ClothingWindow
    {
        public ClothingWindow()
        {
            InitializeComponent();
            // Note: no need to set the DataContext for the ComboBox.
            DataContext = new ClothingViewModel();
        }
    }
