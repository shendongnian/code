     public partial class MainWindow : Window
        {
            public string Debt
            {
                get { return (string)GetValue(DebtProperty); }
                set { SetValue(DebtProperty, value); }
            }
    
           
            public static readonly DependencyProperty DebtProperty =
                DependencyProperty.Register("Debt", typeof(string), typeof(MainWindow), new PropertyMetadata(string.Empty));
    
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = this;
                this.Debt = "Test";
            }
        }
