XAML
    <Grid>
        <ComboBox x:Name="cmbBuilding" Width="100" Height="25" ItemsSource="{Binding Path=Beams}">
            <ComboBox.ItemTemplate>
                <DataTemplate>
                    <Grid Width="300">
                        <TextBlock Width="150" Text="{Binding Path=Story}" HorizontalAlignment="Left" />
                        <TextBlock Width="150" Text="{Binding Path=Elevation}" HorizontalAlignment="Right" />
                    </Grid>
                </DataTemplate>
            </ComboBox.ItemTemplate>
        </ComboBox>
        
        <Button Content="Add item" VerticalAlignment="Top" Click="Button_Click" />
    </Grid>
Code-behind
    public partial class MainWindow : Window
    {
        Building building = new Building();
        public MainWindow()
        {
            InitializeComponent();
            building.Beams = new List<Beam>();
            building.Beams.Add(new Beam 
                               { 
                                   Elevation = 320, 
                                   Story = "ST1" 
                               });
            this.DataContext = building;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var b1 = new Beam { Elevation = 320, Story = "ST1" };
            var b2 = new Beam { Elevation = 640, Story = "ST2" };
            building.Beams.Add(b1);
            building.Beams.Add(b2);
            cmbBuilding.Items.Refresh();
        }
    }
    public class Building
    {
        public List<Beam> Beams
        {
            get;
            set;
        }
    }
    public class Beam
    {
        public string Story 
        {
            get;
            set;
        }
        public double Elevation
        {
            get;
            set;
        }
    }
