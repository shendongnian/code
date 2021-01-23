XAML
    <Grid>
        <Button Name="TestButton"
                Width="100"
                Height="25"
                Content="Test" 
                ToolTip="TestToolTip" />
        <Button Name="ShowToolTip" 
                VerticalAlignment="Top"
                Content="ShowToolTip" 
                Click="ShowToolTip_Click" />
    </Grid>
Code-behind
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ShowToolTip_Click(object sender, RoutedEventArgs e)
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
                    toolTip.StaysOpen = false;
                    toolTip.IsOpen = true;
                }
            }  
        }
    }
