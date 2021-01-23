        public partial class MainWindow : Window
        {
        public MainWindow()
        {
            InitializeComponent();
            fillWithToggles();
        }
        public void fillWithToggles()
        {
            for (int i = 0; i < 10; i++)
            {
                ColumnDefinition gridCol = new ColumnDefinition();
                gridCol.Name = "Column" + i.ToString();
                DynamicGrid.ColumnDefinitions.Add(gridCol);
            }
            for (int i = 0; i < 10; i++)
            {
                RowDefinition gridRow = new RowDefinition();
                gridRow.Name = "Row" + i.ToString();
                DynamicGrid.RowDefinitions.Add(gridRow);
            }
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    System.Windows.Controls.Primitives.ToggleButton tb = new ToggleButton();
                    tb.VerticalAlignment = VerticalAlignment.Stretch;
                    tb.HorizontalAlignment = HorizontalAlignment.Stretch;
                    Grid.SetColumn(tb, x);
                    Grid.SetRow(tb,y);
                    DynamicGrid.Children.Add(tb);
                }                
            }
        }}
