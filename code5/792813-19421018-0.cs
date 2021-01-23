    public partial class MainWindow : Window
    {
    	private Button source;
    	public MainWindow()
    	{
    		InitializeComponent();
    		source = Baffle;
    		source.Focus();
    	}
    
    	private void Panel_KeyDown(object sender, KeyEventArgs e)
    	{
    		if (source != null)
    		{
    			if (e.Key == Key.Left)
    			{
    				source.Margin = new Thickness(source.Margin.Left - 1, source.Margin.Top,
    				source.Margin.Right + 1, source.Margin.Bottom);
    			}
    		}
    	}
    }
