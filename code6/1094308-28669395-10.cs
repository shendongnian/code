    public sealed partial class MyUserControl : UserControl
    {
        public static DependencyProperty CustomStateProperty = DependencyProperty.Register(
            "CustomState",
            typeof(string),
            typeof(MyUserControl),
            new PropertyMetadata("SoloLectura", CustomStatePropertyChangedCallback));
    
        public string Estado
        {
            get
            {
                return (string)this.GetValue(CustomStateProperty);
            }
            set
            {
                this.SetValue(CustomStateProperty, value);
            }
        }
    
        static void CustomStatePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var item = GetPadre(d as MyUserControl);
            VisualStateManager.GoToState(item, e.NewValue.ToString(), true);
        }
    
        /// <summary>
        /// Gets the listviewitem parent.
        /// </summary>
        private static ListViewItem GetPadre(FrameworkElement elemento)
        {
            while (elemento != null)
            {
                elemento = VisualTreeHelper.GetParent(elemento) as FrameworkElement;
                if (elemento is ListViewItem)
                    break;
            }
            return elemento as ListViewItem;
        }
    
        public FavoritoControl()
        {
            this.InitializeComponent();
        }
    }
