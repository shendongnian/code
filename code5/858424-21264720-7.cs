    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void UpdateGridColumns(object sender, UpdateColumnsEventArgs e)
        {
            CriteriaGrid.Columns.Clear();
            foreach (RuleField rf in e.Columns)
            {
                DataGridTextColumn c = new DataGridTextColumn();
                c.Header = rf.Header;
                Binding b = new Binding(String.Format("[{0}].Value", rf.Position));
                CriteriaGrid.Columns.Add(c);
                c.Binding = b;
            }
        }
    }
