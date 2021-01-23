    public MainWindow()
        {
            InitializeComponent();
            MyGrid.MouseEnter += MyGrid_MouseEnter;
            MyGrid.MouseLeave += MyGrid_MouseLeave;
        }
        void MyGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (DockStackPanel != null)
            {
                var dur = new Duration(new TimeSpan(0, 0, 0, 0, 500));
                var anim = new DoubleAnimation(0, dur);
                DockStackPanel.BeginAnimation(StackPanel.OpacityProperty, anim);
            }
        }
        void MyGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            var dur = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            var anim = new DoubleAnimation(1, dur);
            DockStackPanel.BeginAnimation(StackPanel.OpacityProperty, anim);
        }
   
