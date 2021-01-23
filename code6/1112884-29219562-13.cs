        public MainWindow()
        {
            InitializeComponent();
            this.Items = GetOriginalItems();
            this.DataContext = this;
            this.ReinitializeColumns(2);
        }
        private void ReinitializeColumns(Int32 columnsCount)
        {
            this.dataGrid.RegenerateColumns<Item, Int32>("MyColumns",
                columnsCount);
        }
