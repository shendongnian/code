    public partial class MyControl : UserControl
        {
            public MyControl()
            {
                InitializeComponent();
            }
    
            public static readonly DependencyProperty NumberProperty = DependencyProperty.Register("Number", typeof(int), typeof(MyControl), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
            public int Number
            {
                get { return (int)GetValue(NumberProperty); }
                set { SetValue(NumberProperty, value); }
            }
    
            private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
            {
                e.Handled = true;
                this.Number = 1000;
            }
    
        }
