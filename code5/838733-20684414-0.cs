        namespace WpfApplication2
        {
            /// <summary>
            /// Interaction logic for MainWindow.xaml
            /// </summary>
            public partial class MainWindow : Window
            {
                
                public MainWindow()
                {
                    InitializeComponent();
                    this.DataContext = this; 
                }
                
               
            }
            public  class  WindowMessagesManager
            {
                private static string _header;
                public static string Header1
                {
                    get { return "My Header"; }
                    set { _header = value; }
                }
        
            }
    
    }
    <Window x:Class="WpfApplication2.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml" xmlns:prop="clr-namespace:WpfApplication2"
            Title="MainWindow" Height="350" Width="525">
        <Window.Resources>
            <prop:WindowMessagesManager x:Key="window" ></prop:WindowMessagesManager>
            //you can  try to uncomment this and you will get an exception 
            <!--<prop:MainWindow x:Key="window"></prop:MainWindow>-->
        </Window.Resources>
        <Grid>
            <Menu>
            <MenuItem  Height="100" Width="100" Header="{Binding  Source={StaticResource ResourceKey=window}, Path=Header1}"></MenuItem>
            </Menu>
        </Grid>
    </Window>
