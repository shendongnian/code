     Grid customGrid = new Grid();
            public MainWindow(){
            
                InitializeComponent();          
    
                var tb = new TextBlock();
                tb.Text = "sdasdadsas1";
                customGrid.Children.Add(tb);
                
                tb = new TextBlock();
                tb.Text = "sdassssdas2";
                customGrid.Children.Add(tb);
    
                tb = new TextBlock();
                tb.Text = "sdasdas3";
                customGrid.Children.Add(tb);
               
                this.DataContext = this;
                
            }
    
            public Grid gridTest
            {
                get { return customGrid; }
                set { customGrid = value; }
            }
