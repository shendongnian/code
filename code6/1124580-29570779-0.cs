     <Window.Resources>
        <DataTemplate DataType="{x:Type entities:Facility}">
            <Grid>
                <TextBlock Text="{Binding FacilityName}" />
            </Grid>
        </DataTemplate>
        <DataTemplate DataType="{x:Type entities:Containment}">
            <Grid>
                <TextBlock Text="{Binding ContainmentName}"/>
            </Grid>
        </DataTemplate>
        <DataTemplate DataType="{x:Type entities:Tank}">
            <Grid>
                <TextBlock Text="{Binding TankName}"></TextBlock>
            </Grid>
        </DataTemplate>
    </Window.Resources>
    <Grid Margin="5" Height="Auto">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition Height="*"/>
            <RowDefinition Height="30"/>
        </Grid.RowDefinitions>
        <ScrollViewer Grid.Row="0" Grid.Column="1" Margin="5" VerticalScrollBarVisibility="Visible" DataContext="{Binding SelectedItem}">
            <ContentControl Content="{Binding }"/>
        </ScrollViewer>
        <Button Content="Save" Grid.Row="1" Grid.ColumnSpan="2" Grid.Column="0" Width="60" Height="25" Margin="0,0,5,0"  HorizontalAlignment="Right"/>
    </Grid>
    public partial class Download : Window
    {
        public Download()
        {
            InitializeComponent();
            this.DataContext = new VisioFacilityExportViewModel();
        }
    }
    public class VisioFacilityExportViewModel : INotifyPropertyChanged
    {
        public VisioFacilityExportViewModel()
        {
            //SelectedItem = new Facility() { FacilityName = "Facility" };
            //SelectedItem = new Tank() { TankName = "Tank" };
            SelectedItem = new Containment() { ContainmentName = "Containment" };
        }
        private  object _selectedItem = null;
        public object SelectedItem
        {
            get { return _selectedItem; }
            private set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    NotifyPropertyChanged("SelectedItem");
                }
            }
        }
        #region iNotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        #endregion
    }
    public class Tank
    {
        private string myVar;
        public string TankName
        {
            get { return myVar; }
            set { myVar = value; }
        }
        
    }
    class Facility
    {
        private string myVar;
        public string FacilityName
        {
            get { return myVar; }
            set { myVar = value; }
        }
    }
    class Containment
    {
        private string myVar;
        public string ContainmentName
        {
            get { return myVar; }
            set { myVar = value; }
        }
    }
