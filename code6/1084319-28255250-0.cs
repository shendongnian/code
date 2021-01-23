    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            VM v = new VM();
            v.djurKatList = new List<string>();
            v.djurKatList.Add("1");
            v.djurKatList.Add("2");
            v.djurKatList.Add("3");
            v.djurKatList.Add("4");
            v.djurKatList.Add("5");
            DataContext = v;
        }
        private void listKat_SelectionChanged(object sender, SelectionChangedEventArgs e) {
           // fyllDjurArtLista(hanterare, typeof(Daggdjur));
        }
    }
    public class VM {
        public List<string> djurKatList { get; set; }
        public string SelectedDjurKat { get; set; }
    }
    <Window x:Class="WpfApplication1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="350" Width="525">
    <Grid>
        <StackPanel>
            <!--1st list -->
            <ComboBox ItemsSource="{Binding djurKatList}" SelectedItem="{Binding SelectedDjurKat}" SelectionChanged="listKat_SelectionChanged"
                      x:Name="listKat" HorizontalAlignment="Left" Margin="98,118,0,0" VerticalAlignment="Top" Width="120"/>
            <!--2nd list that's filled after something is selected in 1st list-->
            <ComboBox ItemsSource="{Binding djurArtList}" SelectedItem="{Binding SelectedDjurArt}" x:Name="listDjur" HorizontalAlignment="Left"
                      Margin="98,154,0,0" VerticalAlignment="Top" Width="120"/>
        </StackPanel>
    </Grid>
