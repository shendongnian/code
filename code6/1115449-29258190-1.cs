    public partial class MainWindow : Window
    {
      public DependencyProperty TestValueProperty = DependencyProperty.Register("testvalue", typeof(int), typeof(MainWindow));
      public int testvalue
      {
        get { return (int)GetValue(TestValueProperty); }
        set
        {
          SetValue(TestValueProperty, value);
        }
      }
      public MainWindow()
      {
        InitializeComponent();
        testvalue = 6;
        Tag = this;
        testvalue = 7;
      }
    }
