         public Form1()
         {
            InitializeComponent();
            // Override the paint-method for the menuItem
            selectColorToolStripMenuItem.Paint += OnDrawItem;
         }
