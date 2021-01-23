        List<SomeInfo> list = new List<SomeInfo>();
        public MainWindow()
        {
            InitializeComponent();
            list.Add(new SomeInfo() { Name = "PC", Description = "Computer", ID = 1 });
            list.Add(new SomeInfo() { Name = "PS", Description = "Playstation", ID = 2 });
            list.Add(new SomeInfo() { Name = "XB", Description = "Xbox", ID = 3 });
            this.dg.ItemsSource = list;
        }
        public class SomeInfo
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int ID { get; set; }
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedIndex != -1)
            {
                DataGrid dataGrid = sender as DataGrid;
                DataGridRow row = (DataGridRow)dg.ItemContainerGenerator.ContainerFromIndex(dg.SelectedIndex);
                DataGridCell RowColumn = dg.Columns[0].GetCellContent(row).Parent as DataGridCell;
                btn.Content = ((TextBlock)RowColumn.Content).Text;
            }
        }
