XAML
    <Window x:Class="AutoResizeProblem.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525"
            Loaded="Window_Loaded"
            SizeToContent="Height">
    
        <DockPanel Name="MasterDockPanel" Background="Aquamarine">
            <TabControl SelectionChanged="TabControl_SelectionChanged">
                <TabItem Header="Test1">
                    <TextBlock Name="Test1Content" Background="Red" Height="100">TEST1</TextBlock>
                </TabItem>
            
                <TabItem Header="Test2">
                    <TextBlock>TEST2</TextBlock>
                </TabItem>
                <TabItem Header="Test3">
                    <TextBlock>TEST3</TextBlock>
                </TabItem>
            </TabControl>       
        </DockPanel>
    </Window>
Code-behind
    public partial class MainWindow : Window
    {
        double _initWindowHeight = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _initWindowHeight = this.Height;
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_initWindowHeight > 0)
                this.Height = _initWindowHeight;            
        }
    }
