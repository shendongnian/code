    public MainWindow()
    {
        InitializeComponent();
 
        // Add some sample tabs to the tab control
        for (int i = 0; i < 5; i++)
        {
            TabItem ti = new TabItem() { Header = String.Format("Tab {0}", i + 1) };
            ti.PreviewMouseDown += ti_PreviewMouseDown;
            MyTabControl.Items.Add(ti);
        }
    }
