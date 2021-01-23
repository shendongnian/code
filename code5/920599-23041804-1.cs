XAML
    <Grid>
        <Button Name="TestButton" Width="100" Height="25" Content="Test" ToolTip="TestToolTip" />
        <Button VerticalAlignment="Top" Content="ShowToolTip" Click="Button_Click" />
    </Grid>
Code-behind
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var toolTip = new ToolTip();
            if (TestButton.ToolTip != null)
            {
                if (TestButton.ToolTip is ToolTip)
                {
                    var castToolTip = (ToolTip)TestButton.ToolTip;
                    castToolTip.IsOpen = true;
                }
                else
                {
                    toolTip.Content = TestButton.ToolTip;
                    toolTip.IsOpen = true;
                }
            }  
        }
    }
