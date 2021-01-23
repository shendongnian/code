    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <ListBox ItemsSource="{Binding Path=DeferedItems}" 
                    ScrollViewer.IsDeferredScrollingEnabled="True" 
                    ScrollViewer.VerticalScrollBarVisibility="Visible"
                    VirtualizingStackPanel.VirtualizationMode="Standard">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <StackPanel>
                        <TextBlock Text="{Binding Path=ID}"/>
                        <ListBox ItemsSource="{Binding Path=DefStrings}" Margin="10,0,0,0" 
                                 MaxHeight="300" 
                                 ScrollViewer.VerticalScrollBarVisibility="Visible"/>
                        <TextBlock Text="{Binding Path=DT}" Margin="10,0,0,0"/>                      
                    </StackPanel>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
    </Grid>
    
    public partial class MainWindow : Window
    {
        private List<DeferedItem> deferedItems = new List<DeferedItem>();
        public MainWindow()
        {
            this.DataContext = this;
            for (Int32 i = 0; i < 100000; i++) deferedItems.Add(new DeferedItem(i));
            InitializeComponent();
        }
        public List<DeferedItem> DeferedItems { get { return deferedItems; } }
            
    }
    public class DeferedItem
    {
        private Int32 id;
        private DateTime? dt = null;
        private List<String> defStrings = new List<string>();
        public DateTime DT
        {
            get
            {
                if (dt == null)
                {
                    System.Threading.Thread.Sleep(1000);
                    dt = DateTime.Now;
                }
                return (DateTime)dt;
            }
        }
        public List<String> DefStrings
        {
            get
            {
                if (defStrings.Count == 0)
                {
                    for (Int32 i = id; i < id + 1000; i++) defStrings.Add(i.ToString() + " " + DateTime.Now.ToLongTimeString());
                }
                return defStrings;
            }
        }
        public Int32 ID { get { return id; } }
        public DeferedItem(Int32 ID) { id = ID; }
    }
