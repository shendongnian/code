    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Creat datagrid columns.Can also be done in xaml. but for short i have done in .cs 
            CreateCoulmns();
            DataContext = new ViewModel();
        }
        void CreateCoulmns()
        {
            var converter = new BackGroundConverter();
            for (int i = -1; i < 35; i++)
            {
                DataGridTextColumn dataGridTextColumn = new DataGridTextColumn();
                if (i == -1)
                {
                    dataGridTextColumn.Header = "Month / Day";
                    dataGridTextColumn.Binding = new Binding("MonthName");
                }
                else
                {
                    switch (i % 7)
                    {
                        case 0: dataGridTextColumn.Header = "Mo"; break;
                        case 1: dataGridTextColumn.Header = "Tu"; break;
                        case 2: dataGridTextColumn.Header = "We"; break;
                        case 3: dataGridTextColumn.Header = "Th"; break;
                        case 4: dataGridTextColumn.Header = "Fr"; break;
                        case 5: dataGridTextColumn.Header = "Sa"; break;
                        case 6: dataGridTextColumn.Header = "Su"; break;
                    }
                    dataGridTextColumn.Binding = new Binding(string.Format("Days[{0}].NumericDay", i));
                    //Set BackGround property in style and use converter to set background according to HolidayType
                    dataGridTextColumn.CellStyle = new Style(typeof(DataGridCell));
                    dataGridTextColumn.CellStyle.Setters.Add(
                        new Setter
                        {
                            Property = DataGridCell.BackgroundProperty,
                            Value = new Binding(string.Format("Days[{0}]", i)) { Converter = converter }
                            
                        });
                }
                dataGrid.Columns.Add(dataGridTextColumn);
            }
        }
    }
