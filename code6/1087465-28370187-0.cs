    <Grid>
        <DataGrid AutoGenerateColumns="False" Name="dgr" ItemsSource="{Binding GridItems}" >
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding Name}" >
                    <DataGridTextColumn.Header>
                        <StackPanel Orientation="Horizontal">                           
                            <TextBlock Text="combo" Grid.Row="0"/>
                            <ComboBox Grid.Row="1" Width="70" HorizontalAlignment="Center" Name="cboBhp" 
                                               ItemsSource="{Binding Path=DataContext.ComboItems, 
                                                RelativeSource={RelativeSource AncestorType={x:Type Window}}}" 
                                      SelectedValue="{Binding Path=DataContext.ComboValue, RelativeSource={RelativeSource AncestorType={x:Type Window}}, 
                                Mode=TwoWay}">
                            </ComboBox>
                        </StackPanel>
                    </DataGridTextColumn.Header>
                </DataGridTextColumn>
               
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }
    }
    public class GridSample
    {
        public string Name { get; set; }
       
    }
   
    public class MainViewModel:INotifyPropertyChanged
    {
        private string comboValue;
        public string ComboValue
        {
            get { return comboValue; }
            set
            {
                if (comboValue != value)
                {
                    comboValue = value;
                    NotifyPropertyChanged("ComboValue");
                }
            }
        }
        public MainViewModel()
        {
            ComboItems = new ObservableCollection<string>();
            ComboItems.Add("pascal");
            ComboItems.Add("Braye");
            ComboValue = "pascal";
            GridItems = new ObservableCollection<GridSample>() {
            new GridSample() { Name = "Jim"} ,new GridSample() { Name = "Adam"} };
            
        }
        public event PropertyChangedEventHandler PropertyChanged; 
        private void NotifyPropertyChanged(string str)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(str));
            }
        }
        public ObservableCollection<GridSample> GridItems { get; set; }
       
        public ObservableCollection<string> ComboItems { get; set; }
    }
