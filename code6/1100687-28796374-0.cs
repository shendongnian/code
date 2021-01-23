     <Grid>
        <Grid.Resources>
            <DataTemplate DataType="{x:Type local:CurrentlySelectedServerViewModel}">
                <local:CurrentlySelectedServerUserControl />
            </DataTemplate>
        </Grid.Resources>
        <ContentControl Content="{Binding Path=CurrentlySelectedServer,
                          RelativeSource={RelativeSource Mode=FindAncestor,
                                                         AncestorType=Window}}" Grid.Row="1"/>
    </Grid>
     public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();            
            
        }
        protected CurrentlySelectedServerViewModel _currentlySelectedServer = new CurrentlySelectedServerViewModel();
        public CurrentlySelectedServerViewModel CurrentlySelectedServer
        {
            get { return _currentlySelectedServer; }
            set { _currentlySelectedServer = value; }
        }
    }
    public class CurrentlySelectedServerViewModel
    {
    }   
