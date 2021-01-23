    <ListBox SelectedItem="{Binding SelectedItem}" ItemsSource="{Binding Buttons}" SelectionChanged="ListBox_SelectionChanged">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <Button Content="{Binding .}" Click="Button_Click">
                        <Button.Background>
                            <LinearGradientBrush EndPoint="0.5,1" StartPoint="0.5,0">
                                <GradientStop Color="#FF000000" Offset="0"/>
                                <GradientStop Color="#15FFFFFF" Offset="1"/>
                            </LinearGradientBrush>
                        </Button.Background>
                    </Button>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            Buttons = new List<string> { "Theme 1", "Theme 2", "Theme 3" };
            this.DataContext = this;
        }
        private string _selectedItem;
        public string SelectedItem
        { 
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                FirePropertyChanged("SelectedItem");
            }
        }
        private List<string> _buttons;
        public List<string> Buttons
        {
            get { return _buttons; }
            set
            {
                _buttons = value;
                FirePropertyChanged("Buttons");
            }
        }
        #region INotifyPropertyChange
        public event PropertyChangedEventHandler PropertyChanged;
        protected void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            if (b != null)
            {
                SelectedItem = b.Content as string;
            }
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
