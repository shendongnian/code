    InkCanvas Customized class with ToolTip:
    ---------------------------
    
    [DebuggerDisplay("[{Scene}]Strokes:{Strokes.Count}, Children:{Children.Count}")]
    public class InkCanvas_SandeepJadhav : InkCanvas
    {
        public InkCanvas_SandeepJadhav(string toolTip)
        {
            ToolTip = toolTip;
        }
    }
    
    Inkcanvas class created dynamically.
    ------------------------------------
    
    public partial class MainWindow : Window
    {
        public InkCanvas_SandeepJadhav currCanvas = null;
        double width = 0, height = 0, toolWindowHeight = 0;
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = System.Windows.WindowState.Maximized;
            width = System.Windows.SystemParameters.WorkArea.Width;
            height = System.Windows.SystemParameters.WorkArea.Height;
            currCanvas = new InkCanvas_SandeepJadhav("Sandy");
            currCanvas.Width = width;
            currCanvas.Height = height - 150;
            currCanvas.Background = (System.Windows.Media.Brush)new SolidColorBrush(Colors.Lime);
            toolWindowHeight = (height / 10);
            currCanvas.Margin = new Thickness(0, 0, 0, toolWindowHeight);
            myGrid.Children.Add(currCanvas);
        }
    }
    
    XAML Code
    ---------
    
    <Window x:Class="WpfMultiInkCanvas.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <Grid x:Name="myGrid"></Grid>    
    </Window>
