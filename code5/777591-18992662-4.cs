    namespace WpfStackoverflow
    {
        /// <summary>
        /// Interaction logic for InformationControl.xaml
        /// </summary>
        public partial class InformationControl : UserControl
        {
            public static readonly DependencyProperty TimeToStartProperty;
            static InformationControl()
            {
                //FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata("");
                TimeToStartProperty = DependencyProperty.Register("TimeToStart", typeof(string), typeof(InformationControl), new UIPropertyMetadata(string.Empty, UsernamePropertyChangedCallback));
            }
    
            public string TimeToStart
            {
                get { 
                    return (string)GetValue(TimeToStartProperty); 
                }
                set { 
                    SetValue(TimeToStartProperty, value); 
                }
            }
    
            public InformationControl()
            {
                InitializeComponent();
                string temp = TimeToStart;
    
            }
            private static void UsernamePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                Debug.Print("OldValue: {0}", e.OldValue);
                Debug.Print("NewValue: {0}", e.NewValue);
            }
        }
    }
