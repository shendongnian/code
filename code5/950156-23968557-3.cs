    public partial class MainWindow : Window
    {
        private void CreateDataGridColumns()
        {
            for (int i = 0; i < 10; i++) // Change number of columns here.
            {
                DataGridTemplateColumn templateColumn = 
                      (DataGridTemplateColumn)dataGrid.Resources["TemplateColumn"];
                templateColumn.Header = String.Format("Test {0}", i + 1);
                dataGrid.Columns.Add(templateColumn);
            }
        }
    
        public MainWindow()
        {
            InitializeComponent();
            CreateDataGridColumns();
        }
    }
