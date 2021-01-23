    public partial class Window1 : Window
        {
            DataTable dt = new DataTable();
            public Window1()
            {
                InitializeComponent();
                dt.Columns.Add("Num1", typeof(string));
                dt.Columns.Add("Num2", typeof(string));
                dt.Rows.Add("100", "200");
                dt.Rows.Add("300", "400");
                this.dataGridTest.DataContext = dt;
                this.dataGridTest.RowDetailsVisibilityChanged += new EventHandler<Microsoft.Windows.Controls.DataGridRowDetailsEventArgs>(dataGridTest_RowDetailsVisibilityChanged);
            }
            void dataGrid1_RowDetailsVisibilityChanged(object sender, Microsoft.Windows.Controls.DataGridRowDetailsEventArgs e)
            {
                Microsoft.Windows.Controls.DataGrid  innerDataGrid = e.DetailsElement as Microsoft.Windows.Controls.DataGrid;
                innerDataGrid.ItemsSource = ((IListSource)dt).GetList();
            }
        }
