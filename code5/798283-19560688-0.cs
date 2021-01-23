    public class ClassA : DependencyObject
    {
        /// <summary>
        /// 
        /// </summary>
        public string PropertyA
        {
            get { return (string)GetValue(PropertyAProperty); }
            set { SetValue(PropertyAProperty, value); }
        }
    
        /// <summary>
        /// Identifies the <see cref="PropertyA"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PropertyAProperty =
        DependencyProperty.Register("PropertyA", typeof(string), typeof(ClassA), new PropertyMetadata("A"));
    }
    
    
    public class ClassB : ClassA
    {
        /// <summary>
        /// 
        /// </summary>
        public string PropertyB
        {
            get { return (string)GetValue(PropertyBProperty); }
            set { SetValue(PropertyBProperty, value); }
        }
    
        /// <summary>
        /// Identifies the <see cref="PropertyB"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PropertyBProperty =
        DependencyProperty.Register("PropertyB", typeof(string), typeof(ClassA), new PropertyMetadata("B"));
    
        public ClassB()
        {
            ClassA.PropertyAProperty.OverrideMetadata(typeof(ClassB), new PropertyMetadata(AValuePropertyChanged));
        }
    
        private static void AValuePropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            MessageBox.Show(e.NewValue.ToString());
        }
    }
    
    public partial class MainWindow4 : Window
    {
        /// <summary>
        /// 
        /// </summary>
        public MainWindow4()
        {
            InitializeComponent();
    
            this.Reference = new ClassB();
        }
    
        private ClassB Reference { get; set; }
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
    
    
    
            this.Reference.PropertyA = "hello";
        }
    }
