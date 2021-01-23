    public partial class SearchCardControl : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static readonly DependencyProperty SelectedCardProperty =
            DependencyProperty.Register("SelectedCard", typeof(CardBase), typeof(SearchCardControl), new FrameworkPropertyMetadata(null));
        public InMemoryManager InMemoryManager { get; set; }
        public CardBase SelectedCard
        {
            get { return (CardBase)GetValue(SelectedCardProperty); }
            set
            {
                SetValue(SelectedCardProperty, value);
                this.Notify(PropertyChanged);
            }
        }
        private int _minimumSearchChars;
        public int MinimumSearchChars
        {
            get { return _minimumSearchChars; }
            set { if (value > 0) _minimumSearchChars = value; }
        }
        public string DefaultText { get { return String.Format(Properties.UIStrings.ui_calculator_search_card, MinimumSearchChars); } }
        public SearchCardControl()
        {
            InitializeComponent();
            SearchBox.SetTextWithoutSearching(DefaultText);
            MinimumSearchChars = 2;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchComboBox control = (SearchComboBox)sender;
            if (control.IsSearchNeeded)
            {
                if (control.Text.Length >= MinimumSearchChars)
                    control.ItemsSource = Search(control.Text);
                else
                    control.ItemsSource = new List<object>();
            }
        }
        private void SearchBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchComboBox control = (SearchComboBox)sender;
            if (control.SelectedItem == null)
                control.SetTextWithoutSearching(DefaultText);
            else
            {
                SelectedCard = (CardBase)control.SelectedItem;
                control.SetTextWithoutSearching(SelectedCard.Name);
            }
        }
        private void SearchBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (SelectedCard == null)
                SearchBox.SetTextWithoutSearching(DefaultText);
            else
                SearchBox.Text = SelectedCard.Name;
        }
        private List<CardBase> Search(string partialName)
        {
            // Whatever floats your boat
            // MyList.FindAll(x => x.FieldToCompareForExampleCardName.IndexOf(partialName, StringComparison.OrdinalIgnoreCase) >= 0);
            // Or you could implement a delegate here
        }
    }
    internal class SearchComboBox : ComboBox
    {
        internal bool IsSearchNeeded = true;
        internal SelectionChangedEventArgs LastOnSelectionChangedArgs;
        internal void SetTextWithoutSearching(string text)
        {
            IsSearchNeeded = false;
            Text = text;
            IsSearchNeeded = true;
        }
        protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            if (IsSearchNeeded)
            {
                Text = "";
                IsDropDownOpen = true;
            }
            base.OnGotKeyboardFocus(e);
        }
        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {  
            if (SelectedIndex != -1)
                LastOnSelectionChangedArgs = e;
        }
        protected override void OnDropDownClosed(EventArgs e)
        {
            if (LastOnSelectionChangedArgs != null)
                base.OnSelectionChanged(LastOnSelectionChangedArgs);
            base.OnDropDownClosed(e);
        }
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                IsDropDownOpen = false;
            }
            else if (e.Key == Key.Escape)
            {
                SelectedIndex = -1;
                IsDropDownOpen = false;
            }
            else
            {
                if (e.Key == Key.Down)
                    this.IsDropDownOpen = true;
                base.OnPreviewKeyDown(e);
            }
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (!(e.Key == Key.Up || e.Key == Key.Down || e.Key == Key.Tab || e.Key == Key.Enter))
                base.OnKeyUp(e);
        }
    }
