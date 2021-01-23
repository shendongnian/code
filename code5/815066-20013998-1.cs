        <DataGrid ItemsSource="{Binding Data}" AutoGenerateColumns="False" GridLinesVisibility="None">
            
            <DataGrid.Columns>
                <DataGridTextColumn Header="A" Binding="{Binding A}"/>
                <DataGridTextColumn Header="B" Binding="{Binding B}"/>
                <DataGridTemplateColumn Header="C" Width="Auto">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding Path=C}" Margin="0,5,0,-2"/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
    public class DataClass
    {
        public int A { get; set; }
        public int B { get; set; }
        public String C { get; set; }
        public DataClass(int a, int b, String c)
        {
            A = a;
            B = b;
            C = c;
        }
    }
        public List<DataClass> Data { get; set; }
        public MainWindow()
        {
            Data = new List<DataClass>() { new DataClass(1, 2, "3"), new DataClass(2, 3, "4"), new DataClass(3, 4, "5"), new DataClass(4, 5, "") };
            DataContext = this;
            InitializeComponent();
        }
