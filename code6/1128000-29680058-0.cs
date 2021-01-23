            public MyUserControl1()
            {
                this.InitializeComponent();
                DataContextChanged += OnDataContextChanged;
            }
    
            private void OnDataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
            {
                if (this.DataContext != null)
                {
                   bar = (Bar)DataContext;
                   this.DoSomething((bar);
                }
            }
