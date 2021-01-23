    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent(); 
            TheGrid.ItemsSource = numbers;
        }
        private void Copy(object sender, ExecutedRoutedEventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, string.Join(",", numbers));
        }
        private void CanCopy(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void CanPaste(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }
        private void Paste(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
        private void CanAddNew(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }
        private void AddNew(object sender, ExecutedRoutedEventArgs e)
        {
            numbers.Add(numbers.Count);
        }
        private readonly ICollection<int> numbers = new ObservableCollection<int>();
        private void TheGrid_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            TheGrid.Focus();
        }
    }
