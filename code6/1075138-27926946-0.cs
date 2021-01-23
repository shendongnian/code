    public partial class MyControl : UserControl
    {
        private static readonly DependencyPropertyKey PagesPropertyKey = DependencyProperty.RegisterReadOnly("Pages", typeof(ObservableCollection<XXX>), typeof(MyControl), new FrameworkPropertyMetadata(null,OnPagesChanged));
    
        public static DependencyProperty PagesProperty = PagesPropertyKey.DependencyProperty;
    
        public ObservableCollection<XXX> Pages
        {
            get { return (ObservableCollection<XXX>) base.GetValue(PagesProperty); }
            set { base.SetValue(PagesProperty, value); }
        }
    }
    
            private static void OnPagesChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
            {
    //play with DepedencyObject here; cast it to type MyControl and assign/change instance variables
    //Raise some events which can be bubbled.
    //Set SelectedIndex here
            }
