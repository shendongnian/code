        /// <summary>
    /// Interaction logic for MyTabItem.xaml
    /// </summary>
    public partial class MyTabItem : UserControl
    {
        public static readonly DependencyProperty MyDatasourceProperty = DependencyProperty.Register("MyDatasource", typeof(IEnumerable), typeof(MyTabItem), new PropertyMetadata(default(IEnumerable), MyDataSourceChangedCallback));
        private static void MyDataSourceChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var myobj = d as MyTabItem;
            if (myobj == null) return;
            myobj.MyDataSourceChanged(d, e);
        }
        private void MyDataSourceChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            MyDataGrid.ItemsSource = dependencyPropertyChangedEventArgs.NewValue as IEnumerable;
        }
        public MyTabItem()
        {
            InitializeComponent();
        }
        public IEnumerable MyDatasource
        {
            get { return (IEnumerable)GetValue(MyDatasourceProperty); }
            set { SetValue(MyDatasourceProperty, value); }
        }
    }
