XAML
    <Grid>
        <ItemsControl ItemsSource="{Binding Path=UCItemsSource, 
                                            RelativeSource={RelativeSource Mode=FindAncestor,
                                                                           AncestorType={x:Type UserControl}}}">
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding}" />
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
    </Grid>
Code-behind
    public partial class UserControl1 : UserControl
    {
        #region Public Section
        public ObservableCollection<long> UCItems { get; set; }
        #endregion
        public UserControl1()
        {
            InitializeComponent();
            
            UCItems = new ObservableCollection<long>();
        }
        #region UCItemsSource Property
        public static readonly DependencyProperty UCItemsSourceProperty = DependencyProperty.Register("UCItemsSource", 
                                                                                                      typeof(IEnumerable), 
                                                                                                      typeof(UserControl1));                                                                                                      
        public IEnumerable UCItemsSource
        {
            get { return (IEnumerable)GetValue(UCItemsSourceProperty); }
            set { SetValue(UCItemsSourceProperty, value); }
        }
        #endregion
    }
