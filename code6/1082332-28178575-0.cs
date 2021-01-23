    <DataGrid x:Name="dtgCsvData" HorizontalAlignment="Left" VerticalAlignment="Top" Height="200" Width="250" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding Temperature}" Header="Temperature" IsReadOnly="True"/>
                <DataGridTextColumn Binding="{Binding Time}" Header="Time" IsReadOnly="True" />
            </DataGrid.Columns>            
        </DataGrid>
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {
            InitializeComponent();
            List<MyClass> lst = new List<MyClass>();
            lst.Add(new MyClass() { Temperature = "60 F", Time = "2:30 PM" });
            lst.Add(new MyClass() { Temperature = "62 F", Time = "2:35 PM" });
            dtgCsvData.ItemsSource = lst;
        }        
    }
    class MyClass
    {
        public string Temperature { get; set; }
        public string Time { get; set; }
    }
