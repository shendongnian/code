    // ============================================================================================================================
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                grid.DataContext = new MyClassContainer();
                lst.DataContext = new MyClassContainer();
                ctl.DataContext = new MyClass();
            }
    
            private void TemplateControlLoaded(object sender, RoutedEventArgs e)
            {
                BindingExpression be = (sender as FrameworkElement).GetBindingExpression(MyControl.NumberProperty);
                Console.WriteLine("Template trigger = " + be.ParentBinding.UpdateSourceTrigger.ToString());
            }
    
            private void MyControl_Loaded(object sender, RoutedEventArgs e)
            {
                BindingExpression be = (sender as FrameworkElement).GetBindingExpression(MyControl.NumberProperty);
                Console.WriteLine("Instance trigger = " + be.ParentBinding.UpdateSourceTrigger.ToString());
            }
        }
    
    
        // ============================================================================================================================
        public class MyClassContainer
        {
            public List<MyClass> GameList { get; set; }
    
            public MyClassContainer()
            {
                GameList = new List<MyClass>();
                GameList.Add(new MyClass()
                {
                    Rating = 150
                });
            }
        }
    
    
        // ============================================================================================================================
        public class MyClass : INotifyPropertyChanged
        {
    
    
            private int _Rating;
            public int Rating
            {
                get { return _Rating; }
                set
                {
                    _Rating = value; NotifyChange("Rating");
                    Console.WriteLine("changed!");
                }
            }
    
            private void NotifyChange(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
